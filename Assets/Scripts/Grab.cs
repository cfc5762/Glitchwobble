using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Grab : MonoBehaviour {
    int jumpTimer = 30;
    SteamVR_Controller.Device cont;
    GameObject heldItem = null;
    // Use this for initialization
    void Start()
    {
        cont = GetComponentInParent<Hand>().controller;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jumpTimer < 30)
            jumpTimer += 1;//this gets the timer to 30 in 30 frames
    }
    void Update()
    {
        if (cont != null)
        {

            if (heldItem != null)//held item stuff here 
            {
                if (heldItem.GetComponent<Blaster>() != null)
                {
                    Blaster gun = heldItem.GetComponent<Blaster>();
                    
                    if (cont.GetHairTrigger())
                    {
                        bool blasted = false;
                            for (int i = 0; i < heldItem.transform.childCount; i++)
                            {
                                if (heldItem.transform.GetChild(i).CompareTag("FirePoint"))
                                {
                                    blasted = true;
                                    gun.Blast(heldItem.transform.GetChild(i).transform.position,null,100f);
                                }
                            }
                        if (!blasted)
                        {
                            gun.Blast(null, 100f);
                        }
                        
                        
                    }
                }
            }
            if (cont.Equals(SteamVR_Controller.DeviceRelation.Leftmost)&&GroundScript.OnGround)//left hand stuff goes here
            {
               
                Rigidbody Rig3D = Scenemanager.Player.GetComponent<Rigidbody>();
                Vector3 ovel =  Rig3D.velocity;
                Vector3 vel = Rig3D.velocity;
                Vector2 axis = new Vector3(cont.GetState().rAxis0.x, cont.GetState().rAxis0.y);
                float y = vel.y;
                if (GroundScript.OnGround && cont.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Dashboard_Back)&&jumpTimer>29)
                {
                    vel.y = 5f;
                    jumpTimer = 0;
                }
                ovel.y = 0;
                vel.y = 0;
                
                vel += Vector3.ClampMagnitude(Head.head.transform.forward * axis.y + Rig3D.transform.right * axis.x, .3f * axis.magnitude);
                if (vel.magnitude > 6f * axis.magnitude && ovel.magnitude > vel.magnitude)
                {
                    vel.y = y;
                    Rig3D.velocity = vel;
                }
                else if (vel.magnitude > 6 * axis.magnitude)
                {

                }
                else
                {
                    vel.y = y;
                    Rig3D.velocity = vel;
                }
            }
            if (cont.Equals(SteamVR_Controller.DeviceRelation.Rightmost))//right hand stuff here
            {
                Scenemanager.Player.transform.Rotate(new Vector3(0, 10, 0)* cont.GetState().rAxis0.x);
            }
        }
        else
        {
            cont = GetComponentInParent<Hand>().controller;
        }

    }
    void OnTriggerStay(Collider C)//grabby stuff here
    {

        if (cont != null && cont.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip) && C.gameObject.CompareTag("Grabbable") && transform.childCount < 1)
        {

            C.transform.parent = this.gameObject.transform;
            heldItem = C.gameObject;
            if (C.transform.childCount > 0&& C.transform.GetChild(0).CompareTag("Sweetspot"))
            {
                C.transform.localPosition = -C.transform.GetChild(0).localPosition * C.transform.GetChild(0).localScale.x;
                C.transform.localRotation = Quaternion.Euler(-C.transform.GetChild(0).localRotation.eulerAngles);

            }

        }
        else if (cont != null && cont.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip) && C.gameObject.CompareTag("Grabbable"))
        {
            C.transform.parent = null;
            heldItem = null;
        }
    }
}
