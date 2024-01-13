using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHit : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected int speed;

    [SerializeField]
    protected int gem;

    [SerializeField]
    protected Transform _pointA, _pointB;

    [SerializeField]
    protected Vector3 currentTarget;

    public virtual void Attack()
    {
        Debug.Log("My name is " + this.gameObject.name);
    }


    public abstract void Update();
}
