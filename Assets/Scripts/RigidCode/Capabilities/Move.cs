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

    private Vector3 direction;
    private Vector3 desiredVelocity;
    private Vector3 velocity;
    private Rigidbody body;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;
    // Start is called before the first frame update
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
}
