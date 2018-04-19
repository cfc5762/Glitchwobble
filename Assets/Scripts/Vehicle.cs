using UnityEngine;
using System.Collections;

//use the Generic system here to make use of a Flocker list later on
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]

abstract public class Vehicle : MonoBehaviour {
	//-----------------------------------------------
	//Class fields
	//-----------------------------------------------

	//no position - transform.position will be used instead
	protected Vector3 acceleration;
	protected Vector3 velocity;
	protected Vector3 desired;

	public Vector3 Velocity
	{
		get {return velocity;}
	}

	public float maxSpeed = 6.0f;
	public float maxForce = 12.0f;
	public float mass = 1.0f;
	public float radius = 1.0f ;

    public float safeDistance = 10.0f;
    public float avoidWeight = 100.0f;

	CharacterController charControl;

	abstract protected void CalcSteeringForces();

	//-----------------------------------------------
	//Start and Update
	//-----------------------------------------------
	virtual public void Start(){
		acceleration = Vector3.zero;
		velocity = transform.forward;
		desired = Vector3.zero;

		//store access to character controller component
		charControl = GetComponent<CharacterController>();
	}

	
	// Update is called once per frame
	virtual public void Update () {
		CalcSteeringForces ();

		//add accel to vel
		velocity += acceleration * Time.deltaTime;
		velocity.y = 0;

		//limit velo to max speed
		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //orient the vehicle in the direction of the target
        transform.forward = velocity.normalized;

		//added vel to pos to move
		charControl.Move(velocity * Time.deltaTime);

		//reset accel
		acceleration = Vector3.zero;

	}

	protected void ApplyForce(Vector3 steeringForce){
		acceleration += (steeringForce / mass);
	}

	protected Vector3 Seek(Vector3 targetPosition){
		//calculate the desired velocity from this vehicle's position
		//  toward the target's position
		desired = targetPosition - transform.position;

		//normalize that desired velocity vector
		desired.Normalize();

		//move the vehicle at its maximum speeed toward the target
		desired *= maxSpeed;

		//calculate the resulting force to move this vehicle toward the target
		Vector3 steer = desired - velocity;

		steer.y = 0;

		//return this steering force
		return steer;
	}
}
