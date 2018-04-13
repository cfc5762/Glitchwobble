using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Scenemanager {

	// Use this for initialization
	void Start () {
        Scenemanager.Player = this.gameObject;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Scenemanager.Player = this.gameObject;
    }
}
