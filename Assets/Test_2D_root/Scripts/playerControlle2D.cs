using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class playerControlle2D : MonoBehaviour
{

    [SerializeField] Rigidbody2D playeRB;
    [SerializeField] PlayerInput playerInput;

    

    //referencias generales 
    [SerializeField] Rigidbody2D playerRb; //Ref al rigidbody del player

    [Header("movement Parameters")]
    public float speed;

    [Header("jump Parameters")]
    public float jumpforce;
    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();


    }

    // Update is called once per frame
    void Update()
    {
        //Jump();
    }



    void Movement()
    {

    }

    #region Input Events
    //Para crear un evento:
    //Se define PUBLIC sin tipo de dato (VOID) y con una referencia al input (Callback.Context)
    public void HandleMove(InputAction.CallbackContext context){



    }

    public void HandleJump(InputAction.CallbackContext context){
        
        playerRb.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);
    
    }

    #endregion

}
