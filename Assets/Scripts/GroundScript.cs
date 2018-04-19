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
        transform.position = new Vector3(Head.head.transform.position.x, transform.position.y, Head.head.transform.position.z);
        Debug.DrawLine(transform.position,transform.position - (transform.up * 2f), Color.blue);
        if (Physics.Raycast(transform.position, -transform.up, 2f))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }
    }
    
}
