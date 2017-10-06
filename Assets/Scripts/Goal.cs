﻿using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour {
    //A static field accessible by code anywhere
    static public bool goalMet = false;

    private void OnTriggerEnter(Collider other)
    {
        //When the trigger is hit by something
        //Check to see if it is a Projectile
        if(other.gameObject.tag == "Projectile")
        {
            //If so, set goalMet to tru
            Goal.goalMet = true;
            //Also set the alpha of the color to higher opacity
            Color c = GetComponent<Renderer>().material.color;
            c.a = 1;
            GetComponent<Renderer>().material.color = c;
        }
    }
}
