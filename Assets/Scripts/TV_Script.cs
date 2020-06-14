using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Script : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Script
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	/*
	GameObject OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("[" + currentFile + "] " + collision.gameObject.tag + "has collided into me!, Returning Status");
		return collision.gameObject;
	}
	*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
