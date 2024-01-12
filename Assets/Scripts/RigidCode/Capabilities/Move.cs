using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxspeed = 10f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    public Vector3 direction;
    private Vector3 desiredVelocity;
    private Vector3 velocity;
    private Rigidbody body;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;


    public GameObject startposition;
    public GameObject barrierOne;
    public GameObject barrierTwo;
    public GameObject barrierThree;

    void Awake()
    {
        body= GetComponent<Rigidbody>();
        ground= GetComponent<Ground>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector3(direction.x,0f) * Mathf.Max(maxspeed - ground.GetStaticFriction(), 0f);
    }
    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity= body.velocity;
        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpAdd")
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<Jump>().maxAirJumps = 1;
            this.gameObject.transform.position= startposition.transform.position;
            barrierOne.SetActive(true);
            barrierThree.SetActive(false);

        }
        if(other.tag == "DashAdd")
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<CustomGravity>().canDash = true;
            this.gameObject.transform.position = startposition.transform.position;
            barrierTwo.SetActive(true);
        }
        if (other.tag == "JumpAddTwo")
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<Jump>().maxAirJumps = 1;
            this.gameObject.transform.position = startposition.transform.position;

        }
    }
    
}
