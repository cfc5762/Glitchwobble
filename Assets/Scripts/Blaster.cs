using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {
    
    public float range;
    public float damage = 50.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Blast (GameObject ammo, float distance) {
        RaycastHit target;

        if (Physics.Raycast(transform.position, transform.forward, out target, distance))
        {
            // kill that muthafucka!
            Health healthScript = target.transform.gameObject.GetComponent<Health>();
            if(healthScript != null)
            {
                target.transform.gameObject.GetComponent<Health>().Damage(damage);
            }
        }
    }
    /// <summary>
    /// specify a  launch position for your bullets
    /// </summary>
    /// <param name="position"></param>
    /// <param name="ammo"></param>
    /// <param name="distance"></param>
    public void Blast(Vector3 position, GameObject ammo, float distance)
    {
        RaycastHit target;

        if (Physics.Raycast(position, transform.forward, out target, distance))
        {
            // kill that muthafucka!
            Health healthScript = target.transform.gameObject.GetComponent<Health>();
            if (healthScript != null)
            {
                target.transform.gameObject.GetComponent<Health>().Damage(damage);
            }
        }
    }
}
