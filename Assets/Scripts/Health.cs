using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    float health = 100.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float amt)
    {
        health -= amt;

        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
