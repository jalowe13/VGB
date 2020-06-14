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
	public string collisionItem; //String for what item is colliding
	public string collisionKind; //String for what kind of collision
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
		collisionItem = player.GetComponent<VGB_Script>().CollisionCheck();
		collisionKind = player.GetComponent<VGB_Script>().KindCheck();
    }
	
	void checkEvents() //Checking if a event is running before checking the collision type
	{
		//Precheck
		collisionItem = player.GetComponent<VGB_Script>().CollisionCheck();
		collisionKind = player.GetComponent<VGB_Script>().KindCheck();
		//Debug.Log("[" + currentFile + "] " + "Event not running in tv is " + dialogueEvents.GetComponentInChildren<TypeWriterText>().eventNotRunning);
		//Check
			//Debug.Log("[" + currentFile + "] " + "checking collision tag " + player.GetComponent<VGB_Script>().CollisionCheck());
			TVCollision(); //Check if colliding with TV
			DoorsCollision();
	}
	
	
	void TVCollision() //Checking if TV Collision
	{
		if(collisionItem == "TV")
		{
			//Debug.Log("VGB is touching the TV");
			if(player.GetComponent<VGB_Script>().KindCheck() == "enter")
			{
				dialogueEvents.SetActive(true); //Turn on dialouge box
				dialogueEvents.GetComponentInChildren<TypeWriterText>().displayEvent(); //Type out dialouge
			}
			if (player.GetComponent<VGB_Script>().KindCheck() == "exit")
			{
				dialogueEvents.SetActive(false); //Turn off dialouge box
			}
		}
	}
    void DoorsCollision() //Checking if Door Collision
	{
		//Debug.Log("Collision Item: " + collisionItem);
		if(collisionItem == "Doors")
		{
			//Debug.Log("VGB is touching a door");
			if(player.GetComponent<VGB_Script>().KindCheck() == "stay")
			{
				door.GetComponent<DoorScript>().OpenDoor();
			}
			if (player.GetComponent<VGB_Script>().KindCheck() == "exit")
			{
				door.GetComponent<DoorScript>().CloseDoor();
			}
		}
	}
	// Update is called once per frame
    void Update()
    {
		checkEvents();
    }
}
