using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBG_ROOM_EVENTS : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Script
	public GameObject player; //Reference of the player Object
	public GameObject TV; //Reference of the TV object
	public GameObject door; //Reference of the Door Object
	public GameObject dialogueEvents; // Reference of Text to enable to speech
	public bool eventNotRunning;
	//[SerializeField] private Script vgb;
	/*
	public Script player_script;
	public BoxCollider2D player_box; //Reference of player Collider
	public BoxCollider2D tvBox; //Reference of the TV Object Collider
	*/
	public bool tvBoxTouch;
    // Start is called before the first frame update
    void Start()
    {
		eventNotRunning = true;
    }
	
	void checkEvents() //Checking if a event is running before checking the collision type
	{
		//Precheck
		eventNotRunning = dialogueEvents.GetComponentInChildren<TypeWriterText>().eventNotRunning;
		eventNotRunning = door.GetComponent<DoorScript>().eventNotRunning;
		//Debug.Log("[" + currentFile + "] " + "Event not running in tv is " + dialogueEvents.GetComponentInChildren<TypeWriterText>().eventNotRunning);
		//Check
		if (eventNotRunning) // If a event is not currently running
		{
			Debug.Log("[" + currentFile + "] " + "checking collision tag " + player.GetComponent<VGB_Script>().CollisionCheck());
			TVCollision(); //Check if colliding with TV
			DoorsCollision();
		}
	}
	
	
	void TVCollision() //Checking if TV Collision
	{
		if(player.GetComponent<VGB_Script>().CollisionCheck() == "TV")
		{
			dialogueEvents.SetActive(true);
			dialogueEvents.GetComponentInChildren<TypeWriterText>().displayEvent();
		}
	}
    void DoorsCollision() //Checking if Door Collision
	{
		if(player.GetComponent<VGB_Script>().CollisionCheck() == "Doors")
		{
			Debug.Log("VGB is touching a door");
			door.GetComponent<DoorScript>().OpenDoor();
			//eventNotRunning = false;
			//Debug.Log("[" + currentFile + "] " + " found event TV Collision");
			//dialogueEvents.SetActive(true);
			//dialogueEvents.GetComponentInChildren<TypeWriterText>().displayEvent();
		}
	}
	// Update is called once per frame
    void Update()
    {
		checkEvents();
    }
}
