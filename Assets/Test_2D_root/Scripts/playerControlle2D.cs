using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem; //Libreria para que funcione el input sistem

public class playerControlle2D : MonoBehaviour
{

    //Referenciaas generales
    [SerializeField] Rigidbody2D playerRB; //Ref rigibody
    [SerializeField] PlayerInput playerInput; //Ref input de player
    [SerializeField] Animator playerAnim; //Ref animator para gestion de transición animaciones 


    [Header("movement Parameters")]
    private Vector2 moveInput; //Almacén del input del player
    public float speed;
    [SerializeField] bool isFacingRight;


    [Header("jump Parameters")]
    public float jumpforce;
    [SerializeField] bool isGrounded;
    //Variables para el Groundcheck
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 01f;
    [SerializeField] LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {

        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        isFacingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
        GroundCheck();

        //Flip
        if (moveInput.x > 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (moveInput.x < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {

        playerRB.velocity = new Vector3(moveInput.x * speed, playerRB.velocity.y, 0);

    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //nombre de bool = ! nombre de bool (cambio al estado contrario)
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
    }

    void HandleAnimations()
    {
        //Conector de valores generales con parámetros de cambios de animación
        playerAnim.SetBool("isJumping", !isGrounded);
        if (moveInput.x > 0 || moveInput.x < 0) playerAnim.SetBool("isRunning", true);
        else playerAnim.SetBool("isRunning", false);
    }

    #region Input Events
    //Para crear un evento:
    //Se define PUBLIC sin tipo de dato (VOID) y con una referencia al input (Callback.Context)
    public void HandleMove(InputAction.CallbackContext context){

        moveInput = context.ReadValue<Vector2>();

    }

    public void HandleJump(InputAction.CallbackContext context){
        
        if (context.started)
        {
            if (isGrounded)
            {
                playerRB.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);

            }
        }
        
    
    }

    #endregion

}
