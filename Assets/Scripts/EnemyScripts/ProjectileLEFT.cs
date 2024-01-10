using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLEFT : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
