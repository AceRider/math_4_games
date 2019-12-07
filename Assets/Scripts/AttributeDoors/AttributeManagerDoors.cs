using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManagerDoors : MonoBehaviour
{
    public static int MAGIC = 16;
    public static int FLY = 8;
    public static int CHARISMA = 4;
    public static int INTELLIGENCE = 2;
    public static int INVISIBLE = 1;
    public Text attributeDisplay;
    int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MAGIC")
        {
            attributes ^= MAGIC;
        }
        else if (other.gameObject.tag == "FLY")
        {
            attributes ^= FLY;
        }
        else if (other.gameObject.tag == "CHARISMA")
        {
            attributes ^= CHARISMA;
        }
        else if (other.gameObject.tag == "INTELLIGENCE")
        {
            attributes |= INTELLIGENCE;
        }
        else if (other.gameObject.tag == "INVISIBLE")
        {
            attributes |= INVISIBLE;
        }
        else if (other.gameObject.tag == "ANTIMAGIC")
        {
            attributes &= ~MAGIC;
        }
        else if (other.gameObject.tag == "REMOVE")
        {
            attributes &= ~(INTELLIGENCE | MAGIC);
        }
        else if (other.gameObject.tag == "ADD")
        {
            attributes |= (INTELLIGENCE | MAGIC | CHARISMA);
        }
        else if (other.gameObject.tag == "RESET")
        {
            attributes = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(0, '0');
    }
       
}
