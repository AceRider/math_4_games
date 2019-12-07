using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    static public int BLUEKEY = 4;
    static public int REDKEY = 2;
    static public int GREENKEY = 1;

    public Text attributeDisplay;
    public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BLUE_KEY")
        {
            attributes |= BLUEKEY;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "RED_KEY")
        {
            attributes |= REDKEY;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "GREEN_KEY")
        {
            attributes |= GREENKEY;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "GOLD_KEY")
        {
            attributes |= (BLUEKEY | REDKEY | GREENKEY);
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string A = "110111";
        string B = "10001";
        string C = "1101";
        int aBits = Convert.ToInt32(A, 2);
        int bBits = Convert.ToInt32(B, 2);
        int cBits = Convert.ToInt32(C, 2);

        int packed = 0;

        packed = packed | (aBits << 28);
        packed = packed | (bBits << 25);
        packed = packed | (cBits << 20);

        Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
