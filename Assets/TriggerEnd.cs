using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEnd : MonoBehaviour
{
    public TextMeshProUGUI Box;

    public string Text;

    public GameObject[] enabletrigger , disabletrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Box.text = Text;
            foreach(GameObject g in enabletrigger)
            {
                g.SetActive(true);
            }
            foreach(GameObject g in disabletrigger)
            {
                g.SetActive(false);
            }
           
        }
    }
}
