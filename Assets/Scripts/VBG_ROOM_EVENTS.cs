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
	public GameObject TVText;
	public GameObject DoorText;
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
			player.GetComponent<VGB_Script>().ResetCollisionCheck();
	}
	
	
	void TVCollision() //Checking if TV Collision
	{
		if(collisionItem == "TV")
		{
			//Debug.Log("VGB is touching the TV");
			if(player.GetComponent<VGB_Script>().KindCheck() == "enter")
			{
				TVText.SetActive(true); //Turn on dialouge box
				TVText.GetComponent<TypeWriterText>().displayEvent(); //Type out dialouge
			}
			if (player.GetComponent<VGB_Script>().KindCheck() == "exit")
			{
				TVText.SetActive(false); //Turn off dialouge box
			}
		}
	}
    void DoorsCollision() //Checking if Door Collision
	{
		//Debug.Log("Collision Item: " + collisionItem);
		if(collisionItem == "Doors")
		{
		//Debug.Log("VGB is touching a door");
			if(player.GetComponent<VGB_Script>().KindCheck() == "enter" )
			{
				//Debug.Log("Entering door");
				door.GetComponent<DoorScript>().OpenDoor();
				if(door.GetComponent<DoorScript>().isLocked)
                {
					DoorText.SetActive(true);
					DoorText.GetComponent<TypeWriterText>().displayEvent();
                }
				//DoorText.GetComponent<DoorScript>().OpenDoor();
			}
			if (player.GetComponent<VGB_Script>().KindCheck() == "exit")
			{
				Debug.Log("Exiting door");
				door.GetComponent<DoorScript>().CloseDoor();
				DoorText.SetActive(false);

			}
		}
	}


	// Update is called once per frame
    void Update()
    {
		checkEvents();
    }
}
