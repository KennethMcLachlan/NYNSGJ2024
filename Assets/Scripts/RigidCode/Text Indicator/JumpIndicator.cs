using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class NewBehaviourScript : MonoBehaviour
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
        StartCoroutine(JumpIndicator());
    }
    private IEnumerator JumpIndicator()
    {
        //Debug.Log("this is jump phase: "+ player.GetComponent<Jump>().jumpPhase);
        //Debug.Log("this is maxAirJumps: "+ player.GetComponent<Jump>().maxAirJumps);
        if (player.GetComponent<Jump>().jumpPhase != player.GetComponent<Jump>().maxAirJumps)
        {
            text.text = "Extra Jump Avaliable";
        }
        if ((player.GetComponent<Jump>().maxAirJumps +1) == (player.GetComponent<Jump>().jumpPhase))
        {
            text.text = "No Extra Jump Avaliable";
        }
        yield return new WaitForSeconds(0.2f);
    }
}
