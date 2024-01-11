using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaveAttack : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    

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
            Invoke("DestroyWave", 4f);
        }
    }

    void Update()
    {
        ProjectileMovement();
    }

    private void ProjectileMovement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
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

    private void DestroyWave()
    {
        Destroy(gameObject);
    }
}
