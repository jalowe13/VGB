using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Script
	public SpriteRenderer spriteRenderer;
	public BoxCollider2D collideDetect;
	public bool inside;
	public bool eventNotRunning;
	public bool isLocked;
	private bool soundPlayed;
	private AudioSource source;
	
	[SerializeField] private Sprite openLeftImage,openRightImage,closedImage;
	
	
    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>(); // Getting the audio for opening door
		soundPlayed = false;
		isLocked = true;
    }

	public void OpenDoor()
	{
			if(!isLocked)
        {
			collideDetect.isTrigger = true;
			//Debug.Log("Inside!");
			if (!soundPlayed)
			{
				source.Play();
			}
			spriteRenderer.sprite = openLeftImage;

			//collideDetect.enabled = false;
		}
			else
        {
			collideDetect.isTrigger = false;
		}

	}
	public void CloseDoor()
	{
			//Debug.Log("Outside!");
			spriteRenderer.sprite = closedImage;
	}
	



    // Update is called once per frame
    void Update()
    {
		
    }
}
