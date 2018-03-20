using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blaster_scene : MonoBehaviour {

    public GameObject blaster;
    public GameObject ammo;
    KeyCode fireButton = KeyCode.B;
    bool buttonDown;
    bool prevButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        buttonDown = Input.GetKeyDown(fireButton);

        if (buttonDown && !prevButton)
        {
            if (blaster.GetComponent<Blaster>())
            {
                blaster.GetComponent<Blaster>().Blast(ammo, 25.0f);
                Debug.Log("Pew!");
            }
        }

        prevButton = buttonDown;
	}
}
