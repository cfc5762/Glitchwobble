using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    float health = 100.0f;
    public Vector2 positionPlayer = new Vector2(20, 40);
    public Vector2 scalePlayer = new Vector2(60, 20);
    public Texture2D emptyHealthBar;
    public Texture2D fullHealthBar;
    GUIStyle emptyHealthStyle;
    GUIStyle fullHealthStyle;

    //Enemy specific 
    Vector3 targetScreenPos;
    Vector2 scaleEnemy = new Vector2(30, 10);

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        targetScreenPos = Camera.current.WorldToScreenPoint(this.GetComponent<Transform>().position);
	}

    private void OnGUI()
    {
        if (this.gameObject.tag == "Player")
        {
            playerDisplay();
        }
        else if (this.gameObject.tag == "Enemy")
        {
            enemyDisplay();
        }
    }

    public void Damage(float amt)
    {
        health -= amt;

        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    //Handles displaying the player health on the camera GUI
    public void playerDisplay()
    {
        GUI.BeginGroup(new Rect(positionPlayer.x, positionPlayer.y, scalePlayer.x, scalePlayer.y));//Healthbar
            GUI.Box(new Rect(0, 0, scalePlayer.x, scalePlayer.y), emptyHealthBar, GUIStyle.none);//Empty health bar in background
            GUI.BeginGroup(new Rect(0, 0, scalePlayer.x * (health / 100), scalePlayer.y));//Full health bar in front, scales with health in x direction
                GUI.Box(new Rect(0, 0, scalePlayer.x, scalePlayer.y), fullHealthBar, GUIStyle.none);
            GUI.EndGroup();
        GUI.EndGroup();
    }

    //Handles displaying the enemy health above the enemy in world space
    public void enemyDisplay()
    {
        Debug.Log(targetScreenPos);
        GUI.BeginGroup(new Rect(targetScreenPos.x, targetScreenPos.y, scaleEnemy.x, scaleEnemy.y));//Healthbar
            GUI.Box(new Rect(0, 0, scaleEnemy.x, scaleEnemy.y), emptyHealthBar, GUIStyle.none);//Empty health bar in background
            GUI.BeginGroup(new Rect(0, 0, scaleEnemy.x * (health / 100), scaleEnemy.y));//Full health bar in front, scales with health in x direction
                GUI.Box(new Rect(0, 0, scaleEnemy.x, scaleEnemy.y), fullHealthBar, GUIStyle.none);
            GUI.EndGroup();
        GUI.EndGroup();
    }
}
