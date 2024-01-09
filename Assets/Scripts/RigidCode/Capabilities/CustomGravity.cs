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


    // Dash

    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 24.0f;
    private float dashingTime = 0.2f;
    private Vector3 gravity;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void OnEnable()
    {
        body= GetComponent<Rigidbody>();
        body.useGravity = false;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        else if (isDashing)
        {
            return;
        }
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
        else if(isDashing)
        {
            return;
        }
    }
    private IEnumerator Dash()
    {
        Debug.Log("we're in the coroutine");
        canDash = false;
        isDashing = true;
        Vector3 currentGravity = gravity;
        Vector3 noGrav= new Vector3();
        body.AddForce(noGrav, ForceMode.Acceleration);
        body.velocity = new Vector3(this.gameObject.GetComponent<Move>().direction.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.AddForce(currentGravity, ForceMode.Acceleration);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash=true;
    }
}

