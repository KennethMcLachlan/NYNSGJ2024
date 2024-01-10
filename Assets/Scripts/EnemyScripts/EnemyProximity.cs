using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximity : MonoBehaviour
{
    public EnemyBehavior enemy;

    private void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehavior>();
        if (enemy == null)
        {
            Debug.Log("Enemy is NULL");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.PlayerInProximity();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.PlayerOutOfProximity();
        }
    }
}
