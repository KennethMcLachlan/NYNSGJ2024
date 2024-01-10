using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxspeed = 10f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;
    

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float jumpHeight = 30.0f;
    private float yVelocity;
    
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
   // public bool isDash;

    private float dashTime;
    public float defaultSpeed;
    public float defaultTime;
    private bool canDoubleJump;
    private float horizontalInput;
    //public float dashSpeed;
    Rigidbody myRigidBody;
    private CharacterController _controller;

    //Speed multiplier to reduce the speed of the player when they are sludged
    private float _speedMultiplier = 2f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {      
        CalculateMovement();
       // DashMovement();
    }

    void FixedUpdate()
    {
    }

        private void CalculateMovement()
    {
       horizontalInput = Input.GetAxis("Horizontal");
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

    /*private void DashMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
        }

        if (dashTime <= 0)
        {
            //defaultSpeed = speed;
            if (isDash)
                dashTime = defaultTime;
        }
        else
        {
            dashTime -= Time.deltaTime;
            defaultSpeed = dashSpeed;
        }
        isDash = false;
    }
<<<<<<< HEAD
   */


    //Reduces speed of the player when they get sludged by the homing blob
    public void Sludged()
    {
        //Add SFX here
        speed /= _speedMultiplier;
        //Add a color change here
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        Debug.Log("Player has been sludged");
        StartCoroutine(SludgeDuration());

    }

    IEnumerator SludgeDuration()
    {
        yield return new WaitForSeconds(5.0f);
        speed *= _speedMultiplier;
        //Return player color here
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }


}
