using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerText : MonoBehaviour
{
    public TextMeshProUGUI Box;



    public string Text;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Box.text = Text;            
        }
    }


}
