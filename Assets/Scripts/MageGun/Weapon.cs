using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: MonoBehaviour
{
    public float offset;
    public GameObject projectiles;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private void Update()
    {
        Vector3 difference = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f) - transform.position;
        //Debug.Log("this is difference: " + difference);
        float rotZ= Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,rotZ + offset);
        //Debug.Log("time between shots: "+ timeBtwShots);
        if (timeBtwShots <=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("firing a shot");
                Instantiate(projectiles, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}
