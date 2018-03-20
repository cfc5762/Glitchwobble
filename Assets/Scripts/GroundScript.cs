using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {
    public static bool OnGround = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionStay(Collision collision)
    {
        OnGround = true;
    }
    void OnCollisionExit(Collision collision)
    {
        OnGround = false;
    }
}
