using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DashIndicatorSCript : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DashIndicator());
    }
    private IEnumerator DashIndicator()
    {
        
        if (player.GetComponent<CustomGravity>().canDash != true)
        {
            text.text = "Dash Unavailable";
        }
        if (player.GetComponent<CustomGravity>().canDash == true)
        {
            text.text = "Dash Available";
        }
        yield return new WaitForSeconds(0.2f);
    }
}
