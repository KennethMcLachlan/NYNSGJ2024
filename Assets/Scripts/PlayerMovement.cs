using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float jumpHeight = 30.0f;
    private float yVelocity;
    
    [SerializeField]
    private float gravity = 1.0f;
    
    
    private bool canDoubleJump;
    
   // Rigidbody myRigidBody;
    private CharacterController _controller;

    //Speed multiplier/ used to reduce Player speed when sludged
    [SerializeField]
    private float _speedmultiplier = 2f;

    void Start()
    {
        //myRigidBody = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {      
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if(_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
                canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canDoubleJump == true)
                {
                    yVelocity += jumpHeight;
                    canDoubleJump = false;
                }
            }

            yVelocity -= gravity;
        }

        velocity.y = yVelocity;


        _controller.Move(velocity * Time.deltaTime);
    }

    //Reduces speed of the player when they get sludged by the homing blob
    public void Sludged()
    {
        //Add SFX here
        speed /= _speedmultiplier;
        //Add a color change here
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        Debug.Log("Player has been sludged");
        StartCoroutine(SludgeDuration());

    }

    IEnumerator SludgeDuration()
    {
        yield return new WaitForSeconds(5.0f);
        speed *= _speedmultiplier;
        //Return player color here
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
   
}
