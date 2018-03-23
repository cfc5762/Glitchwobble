using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {
    float Vel = 0f;
    Vector3 prevPos = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
    public float Damage = 20;
	// Update is called once per frame
	void FixedUpdate () {
        Vel = (prevPos - transform.position).magnitude;
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null&&Vel>4)
        {
            collision.gameObject.GetComponent<Health>().Damage(Damage);
        }
    }
}
