using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetplatformScript : MonoBehaviour
{
    public GameObject platform;
    private Rigidbody body;
    private Vector3 Startposition;
    private Vector3 ZeroVelo;
    private Quaternion ZeroRota;
    private bool canResawpn;
    // Start is called before the first frame update
    void Start()
    {
        canResawpn = true;

        ZeroVelo = new Vector3(0, 0, 0);
        Startposition = platform.transform.position;
        //Debug.Log("this is startPosition: " + Startposition);
        body = platform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (body.velocity.x == 0 && body.velocity.y == 0 && canResawpn == true)
        {
            
            StartCoroutine(restartPlatforms()); }
            
        //Debug.Log("this is the velocity of the platform: " + body.velocity);
    }
    private IEnumerator restartPlatforms()
    {



            canResawpn = false;
            yield return new WaitForSeconds(3.0f);
            platform.transform.SetPositionAndRotation(Startposition, ZeroRota);
            Vector3 gravity = -9.81f * 1.0f * Vector3.up;
            body.AddForce(gravity, ForceMode.Acceleration);
            yield return new WaitForSeconds(3.0f);
            canResawpn = true;




    }
}
