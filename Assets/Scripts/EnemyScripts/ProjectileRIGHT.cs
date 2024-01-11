using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRIGHT : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    public PlayerHealth player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (player == null)
        {
            Debug.Log("Player is NULL");
        }

        if (gameObject != null)
        {
            Invoke("DestroyProjectile", 4f);
        }
    }
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Damage();
            Destroy(gameObject);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
