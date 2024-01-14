using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }
    private void Update()
    {
        transform.Translate(Vector2.up *speed* Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
