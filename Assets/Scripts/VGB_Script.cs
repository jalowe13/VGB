using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VGB_Script : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Script
	public string eventType;
	//private BoxCollider2D collideDetect;
    // Start is called before the first frame update
    void Start()
    {
		eventType = "unknown";
    }
	void OnCollisionEnter2D(Collision2D collision) //Default Check for Events with Player Trigger
	{
		if (collision.gameObject.tag != "Ground") //Checking for Event Critical Collisions
		{
		//Debug.Log("[" + currentFile + "] " + "Colliding with Scene Event Object " + collision.gameObject);
		eventType = collision.gameObject.tag;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision) //Default Check for Events with Player Trigger Toggle Off
	{
		if (collision.gameObject.tag != "Ground") //Checking for Event Critical Collisions
		{
		//Debug.Log("[" + currentFile + "] " + " Not Colliding with Scene Event Object " + collision.gameObject);
		eventType = "unknown";
		}
	}
	
	void OnCollisionStay2D(Collision2D collision) //Default Check for Events with Player Trigger Toggle Off
	{
		if (collision.gameObject.tag != "Ground") //Checking for Event Critical Collisions
		{
		Debug.Log("[" + currentFile + "] " + " Stay Colliding with Scene Event Object " + collision.gameObject);
		eventType = "unknown";
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision) //Default Check for Events with Player Trigger Toggle Off
	{
		if (collision.gameObject.tag != "Ground") //Checking for Event Critical Collisions
		{
		//Debug.Log("[" + currentFile + "] " + " Triggered by with Scene Event Object " + collision.gameObject);
		eventType = "unknown";
		}
	}
	
	void OnTriggerExit2D(Collider2D collision) //Default Check for Events with Player Trigger Toggle Off
	{
		if (collision.gameObject.tag != "Ground") //Checking for Event Critical Collisions
		{
		//Debug.Log("[" + currentFile + "] " + " Exited Trigger by with Scene Event Object " + collision.gameObject);
		eventType = "unknown";
		}
	}
	
	void OnTriggerStay2D(Collider2D collision) //Default Check for Events with Player Trigger Toggle Off
	{
		if (collision.gameObject.tag != "Ground") //Checking for Event Critical Collisions
		{
		Debug.Log("[" + currentFile + "] " + " Stay Colliding with Scene Event Object " + collision.gameObject);
		eventType = "unknown";
		}
	}
	
	
	public string CollisionCheck()
	{
		return eventType;
	}
	
    // Update is called once per frame
    void Update()
    {
        		
    }
	

	
}
