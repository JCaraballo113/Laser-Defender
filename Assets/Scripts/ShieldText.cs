using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldText : MonoBehaviour 
{

    public void UpdateText(int charges)
    {
        GetComponent<Text>().text = "Charges: " + charges;
    }
}
