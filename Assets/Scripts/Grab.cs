using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Grab : MonoBehaviour {
    int grabTimer = 0;
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
        if (grabTimer > 0)
        {
            grabTimer--;
        }
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
                                gun.Blast(heldItem.transform.GetChild(i).transform.position, null, 100f);
                            }
                        }
                        if (!blasted)
                        {
                            gun.Blast(null, 100f);
                        }


                    }
                }
                //stop held item stuff here
                if (cont != null && cont.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)&&grabTimer<1)
                {
                    heldItem.transform.parent = null;
                    heldItem = null;
                }

               
            }
            if (cont == SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestLeft)))//left hand stuff goes here
            {
               
                Rigidbody Rig3D = Scenemanager.Player.GetComponent<Rigidbody>();
                //print(Scenemanager.Player.name);
                Vector3 ovel =  Rig3D.velocity;
                Vector3 vel = Rig3D.velocity;
                Vector2 axis = new Vector3(cont.GetState().rAxis0.x, cont.GetState().rAxis0.y);
                float y = vel.y;
                if (cont.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Axis0) && GroundScript.OnGround && jumpTimer>29)
                {
                    vel.y = 5f;
                    y = 5f;
                    jumpTimer = 0;
                }
                ovel.y = 0;
                vel.y = 0;
                
                vel += Vector3.ClampMagnitude(Head.head.transform.forward * axis.y + Head.head.transform.right * axis.x, .3f * axis.magnitude);
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
            if (cont == SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestRight)))//right hand stuff here
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
        print("touching");
        if (cont != null && cont.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip) && C.gameObject.CompareTag("Grabbable")&&heldItem==null)
        {
            print("trying");
            C.transform.parent = this.gameObject.transform;
            heldItem = C.gameObject;
            if (heldItem.transform.GetChild(0).CompareTag("SweetSpot")) {
                heldItem.transform.localRotation = Quaternion.Euler(-heldItem.transform.GetChild(0).localRotation.eulerAngles);
                heldItem.transform.position -= heldItem.transform.GetChild(0).position-transform.position;
                
                grabTimer = 5;
                    
                    }

        }
      
    }
}
