using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;
    private Rigidbody body;
    public float gravityScale=1.0f;
    public float globalGravity= -9.81f;
    // Start is called before the first frame update
    void OnEnable()
    {
        body= GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (body.velocity.y == 0f)
        {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            body.AddForce(gravity, ForceMode.Acceleration);
        }
            
        if(body.velocity.y > 0f ) 
        {
            Vector3 gravity = globalGravity * upwardMovementMultiplier * Vector3.up;
            body.AddForce(gravity, ForceMode.Acceleration);
        }
        if (body.velocity.y < 0f)
        {
            Vector3 gravity = globalGravity * downwardMovementMultiplier * Vector3.up;
            body.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}
