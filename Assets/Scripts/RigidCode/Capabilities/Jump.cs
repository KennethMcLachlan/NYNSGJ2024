using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpheight = 3f;
    [SerializeField, Range(0, 2)] public int maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;

    private Rigidbody body;
    private Ground ground;
    private Vector3 velocity;
    private CustomGravity customgrav;

    public int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGround;

    // Start is called before the first frame update
    void Awake()
    {
        body=GetComponent<Rigidbody>();
        ground=GetComponent<Ground>();

        defaultGravityScale = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity=body.velocity;

        if(onGround )
        {
            jumpPhase = 0; 
        }
        if(desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }
        body.velocity = velocity;
    }
    private void JumpAction()
    {
        if (onGround || jumpPhase== maxAirJumps ) 
        {
            //Debug.Log("just jumped here's jump phase: " + jumpPhase);
            jumpPhase += 1;
            ///Debug.Log("this is the globalGrav :" + gameObject.GetComponent<CustomGravity>().globalGravity);
            float jumpSpeed = Mathf.Sqrt(-2f * gameObject.GetComponent<CustomGravity>().globalGravity * jumpheight);
            ///Debug.Log("this is the jumpSpeed before jump action's if loop: " + jumpSpeed);
            if (velocity.y >0f)
            {
                //Debug.Log("this is the jumpSpeed in jump action's if loop: "+ Mathf.Max(jumpSpeed - velocity.y, 0f));
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
        }

    }
}
