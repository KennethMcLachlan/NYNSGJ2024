using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHomingBlob : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _speed = 5f;

    public PlayerHealth player;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _target = player.transform;
    }

    private void Update()
    {
        HomingBlobBehavior();
    }

    public void HomingBlobBehavior()
    {
        if (gameObject != null && player != null)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            transform.up = _target.position - transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player != null)
            {
                player.Damage();
            }
        }
    }
}
