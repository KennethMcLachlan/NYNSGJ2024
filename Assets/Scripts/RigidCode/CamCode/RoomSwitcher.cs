using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    public GameObject virtualCam;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && !other.isTrigger)
        {
            Debug.Log("I am turning on the camera " + virtualCam.name);
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            Debug.Log("I am leaving the camera ");
            virtualCam.SetActive(false);
        }
    }

}
