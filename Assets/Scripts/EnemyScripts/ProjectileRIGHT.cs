using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRIGHT : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
