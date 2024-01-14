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
    public GameObject bossPosition;
    public GameObject barrierOne;
    public GameObject barrierTwo;
    public GameObject barrierThree;
    public GameObject barrierFour;
    public GameObject bossBarrier;
    public GameObject barrierFive;

    private bool maskOne;
    private bool maskTwo;

    private void Start()
    {
        maskTwo = false;
        maskOne = false;
        this.gameObject.GetComponent<Jump>().maxAirJumps = 1;
    }
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
            maskOne = true;


        }
        if (other.tag == "DashAdd")
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<CustomGravity>().canDash = true;
            this.gameObject.transform.position = startposition.transform.position;
            barrierTwo.SetActive(true);
            maskTwo = true;
        }
        if (other.tag == "JumpAddTwo")
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<Jump>().maxAirJumps = 1;
            this.gameObject.transform.position = startposition.transform.position;
            barrierThree.SetActive(true);

        }
        if(other.tag == "TutorialBlock")
        {
            this.gameObject.transform.position = startposition.transform.position;
            this.gameObject.GetComponent<Jump>().maxAirJumps = 0;



        }
        if (other.tag == "FiringLava")
        {
            this.gameObject.GetComponent<PlayerHealth>().DamageSpikes();
        }
        if (other.tag == "Damageing")
        {
            this.gameObject.GetComponent<PlayerHealth>().Damage();
        }
        if (maskTwo&&maskOne)
        {
            barrierFour.SetActive(false);
            bossBarrier.SetActive(true);
            this.gameObject.transform.position = bossPosition.transform.position;
            maskTwo = false;
            maskOne=false;
        }
    }

    public void Sludged()
    {
        //Add SFX here
        maxspeed /= 2;
        //Add a color change here
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        //Debug.Log("Player has been sludged");
        StartCoroutine(SludgeDuration());

    }

    IEnumerator SludgeDuration()
    {
        yield return new WaitForSeconds(5.0f);
        maxspeed *= 2;
        //Return player color here
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

}
