using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenemanager : MonoBehaviour {
    public static readonly object lockObject = new object();
    public static GameObject Player;
    public static List<GameObject> Scene = new List<GameObject>();
	// Use this for initialization
	void Start () {
        lock (Scenemanager.lockObject)
        {
            Scenemanager.Scene.Add(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
