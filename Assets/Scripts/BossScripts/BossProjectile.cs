using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private AudioSource _projectileSFX;

    public PlayerHealth player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (player == null)
        {
            Debug.Log("Player is NULL");
        }

        if (gameObject != null)
        {
            Invoke("DestroyProjectile", 4.5f);
        }

        _projectileSFX = GetComponent<AudioSource>();
        _projectileSFX.Play();
    }

    void Update()
    {
        ProjectileMovement();
    }

    private void ProjectileMovement()
    {
        transform.Translate(Vector3.left * _speed *  Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other != null)
            {
                player.Damage();
                Destroy(gameObject);
            }
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
