using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    float range = 50f;

    public GameObject particleHitPoint;

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
        }

        if (Input.GetButtonDown ("Fire2"))
        {
            magicShoot();
            Debug.Log("spell shot");
        }
    }


    public void magicShoot()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit hit;

        if (Physics.Raycast (rayOrigin, transform.forward, out hit, range))
        {
            if (hit.collider.tag == "target")
            {
                Instantiate(particleHitPoint, hit.point, Quaternion.identity);
                Destroy(hit.collider.gameObject);
            }
        }
    }


    
}
