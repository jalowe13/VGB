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
	private AudioSource source;
	
	[SerializeField] private Sprite openLeftImage,openRightImage,closedImage;
	
	
    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>(); // Getting the audio for opening door
		eventNotRunning = true;
    }
	
/*
	IEnumerator SecondDelay(float seconds)
	{
		yield return new WaitForSeconds(seconds);
			spriteRenderer.sprite = closedImage;
			collideDetect.enabled = true;
			eventNotRunning = true;
	}
	*/
	public void OpenDoor()
	{
			//Debug.Log("Inside!");
			eventNotRunning = false;
			source.Play();
			spriteRenderer.sprite = openLeftImage;
			//collideDetect.isTrigger = true;
			//collideDetect.enabled = false;
	}
	public void CloseDoor()
	{
			//Debug.Log("Outside!");
			//StartCoroutine(SecondDelay(2));
			spriteRenderer.sprite = closedImage;
			//collideDetect.isTrigger = false;
			eventNotRunning = true;
	}
	



    // Update is called once per frame
    void Update()
    {
		
    }
}
