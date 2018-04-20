using UnityEngine;
using System.Collections;

public class Seeker : Vehicle {
	//-----------------------------------------------
	//Class fields
	//-----------------------------------------------
	public GameObject seekerTarget;
    Vector3 idleTarget;
    Vector3 currentTarget;
    bool isSeeking;
    float range = 10;

    public bool IsSeeking
    {
        set { isSeeking = value; }
    }

    //WEIGHTING!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public float seekWeight = 1.0f;

	private Vector3 ultimateForce;

	//-----------------------------------------------
	//Start - No Update
	//-----------------------------------------------
	// Call Inherited Start and then do our own
	override public void Start () {
		base.Start();
        isSeeking = false;
        idleTarget = Vector3.zero;
        currentTarget = Vector3.zero;
		ultimateForce = Vector3.zero;
	}
	

    override public void Update()
    {
        if (isSeeking)
        {
            currentTarget = seekerTarget.transform.position;
            //Debug.Log(currentTarget);
        }
        else
        {
            Wander();
            currentTarget = idleTarget;
        }

        base.Update();
    }

	protected override void CalcSteeringForces(){
		//reset ultimate force
		ultimateForce = Vector3.zero;

		//get a seeking force (based on char movement - for now, just seek)
		//add that seeking force to steering force
		ultimateForce += Seek(currentTarget) * seekWeight;

		//limit the steering force
		ultimateForce = Vector3.ClampMagnitude(ultimateForce, maxForce);

		//apply that steering force to the acceleration (ApplyForce())
		ApplyForce(ultimateForce);
	}

    private void Wander()
    {
        idleTarget = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), transform.position.y, Random.Range(transform.position.z - range, transform.position.z + range));
        transform.LookAt(idleTarget);
    }

}
