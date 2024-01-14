using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    float range = 50f;

    public GameObject particleHitPoint;

    public EnemyBehavior enemy;

    /*
    public void Spell ()
    {
        magicShoot();
        Debug.Log("Clicking shot");
    }
    */


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            magicShoot();
            Debug.Log("click shot");
            enemy.Damage();
        }

        if (Input.GetButtonDown ("Fire2"))
        {
            magicShoot();
            Debug.Log("spell shot");
            enemy.Damage();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            if (enemy != null)
            {
                enemy.Damage();
                Destroy(gameObject);
            }
        }

        
    }

    public void magicShoot()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit hit;

        if (Physics.Raycast (rayOrigin, transform.forward, out hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                Instantiate(particleHitPoint, hit.point, Quaternion.identity);
                Destroy(hit.collider.gameObject);
            }
        }
    }


    
}
