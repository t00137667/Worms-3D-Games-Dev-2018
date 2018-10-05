﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*To use, initialise a FloatingDisplay, and add the component to the object to be displayed above.
 */

public class FloatingDisplay : MonoBehaviour {
    //string healthValue
    // Use this for initialization
    GameObject floatingDisplay;
    TextMesh ourText;

     Health  myHealth;


    // int display = System.Convert.ToInt32(myHealth.health);
    // string displayString = display.ToString();
    string displayString;
    private bool needToUpdateDisplay;

    void Start () {

 

        floatingDisplay = new GameObject("Floating Display");
        floatingDisplay.transform.parent = transform;
        floatingDisplay.transform.localPosition = 1.65f * Vector3.up;


        ourText = floatingDisplay.AddComponent<TextMesh>();
        ourText.text = displayString;             //displayString;
        ourText.anchor = TextAnchor.MiddleCenter;
        ourText.alignment = TextAlignment.Center;
        Font font = Resources.Load<Font>("Pixel Font - Tripfive/Fonts/Tripfive-EX");
        
        MeshRenderer rend = ourText.GetComponent<MeshRenderer>();
        rend.material = font.material;
        ourText.font = font;
        ourText.color = Color.cyan;

        
    }


    public void setDisplay(string newText)
    {
        if (ourText)
        {   ourText.text = newText;
            needToUpdateDisplay = false;
            }
        else
        {
            needToUpdateDisplay = true;
            displayString = newText;
        }

    }
	// Update is called once per frame
	void Update ()
    {
        if (needToUpdateDisplay)
       
            setDisplay(displayString);

        floatingDisplay.transform.rotation = Quaternion.LookRotation((-Camera.main.transform.position+floatingDisplay.transform.position).normalized);//Camera.main.transform.rotation;
	}

    internal void manuallyDestroy()
    {
        Destroy(floatingDisplay);
        Destroy(this);
    }

}
