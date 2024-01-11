using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{
    public PlayerHealth player;

    [SerializeField] private float _speed = 10;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (player == null)
        {
            Debug.Log("Player is NULL");
        }

        if (gameObject != null)
        {
            Invoke("DestroyBomb", 5f);
        }
        
    }

    void Update()
    {
        CalculateMovement();
    }
    
    private void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player != null)
            {
                player.Damage();
                Destroy(gameObject);
            }
        }
    }
}
