using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft_Trigger : MonoBehaviour
{
    public JumpingEnemyBehavior enemy;

    private void Start()
    {
        enemy = GameObject.Find("JumpingEnemy").GetComponent<JumpingEnemyBehavior>();
        if (enemy == null)
        {
            Debug.Log("Jumping Enemy is NULL");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpingEnemy")
        {
            enemy.MoveLeft();
        }
    }
}
