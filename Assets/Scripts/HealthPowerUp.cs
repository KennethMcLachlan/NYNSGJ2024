using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public PlayerHealth player;

    [SerializeField] private AudioSource _healSFX;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (player == null)
        {
            Debug.Log("Player is NULL");
        }

        _healSFX = GameObject.Find("HealSFX").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player != null)
            {
                _healSFX.Play();
                player.Heal();
                Destroy(gameObject);
            }
        }
    }


}
