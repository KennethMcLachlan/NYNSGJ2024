using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    void Start()
    {
        
    }

    void Update()
    {
        ProjectileMovement();
    }

    private void ProjectileMovement()
    {
        transform.Translate(Vector3.left * _speed *  Time.deltaTime);
    }
}
