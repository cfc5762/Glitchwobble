using UnityEngine;
using System.Collections;

public class EnemyFOV : MonoBehaviour
{

    GameObject target;
    Seeker seekerScript;
    float fovAngle = 45;
    public float fovDist = 6.0f;
    GameObject thisGO;

    // Use this for initialization
    void Start()
    {
        thisGO = this.gameObject;
        seekerScript = this.gameObject.GetComponent<Seeker>();
        target = seekerScript.seekerTarget;
    }

    // Update is called once per frame
    void Update()
    {
        seekerScript.IsSeeking = Seek();
    }

    bool Seek()
    {
        bool hitPlayer = false;

        Vector3 direction = target.transform.position - transform.position;
        float targetAngle = Vector3.Angle(direction, transform.forward);
        if (targetAngle < fovAngle && targetAngle > -fovAngle && Vector3.Magnitude(direction) <= fovDist)
        {
            hitPlayer = true;
        }
       

        return hitPlayer;
    }
}
