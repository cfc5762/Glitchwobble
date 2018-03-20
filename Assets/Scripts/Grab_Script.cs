using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Grab_Script : MonoBehaviour {
    SteamVR_Controller.Device cont;
	// Use this for initialization
	void Start () {
        cont = GetComponentInParent<Hand>().controller;
	}
	
	// Update is called once per frame
	void Update () {
        print(cont.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
        print(cont.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis1));
        print(cont.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis2));
        print(cont.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis3));
        print(cont.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis4));
    }
}
