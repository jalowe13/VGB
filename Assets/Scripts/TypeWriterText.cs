using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterText : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Scrip
	public float delay = 0.1f; //Text Write Speed Delay
	public string fullDisp; //Full Line of Dialogue 
	private string currentDisp; //Current Display of Dialogue 
	private AudioSource talkSound; //Sound to play every time a letter is typed

	

    // Start is called before the first frame update
    void Start()
    {
		talkSound = GetComponent<AudioSource>(); //Talk sound
    }

	public void displayEvent() //Function to start dialouge 
	{
		talkSound = GetComponent<AudioSource>();
        StartCoroutine(DisplayText());
		StopCoroutine(DisplayText());
	}
	
    IEnumerator DisplayText() //Typewriter display
	{
		for (int i = 0; i <= fullDisp.Length; i++)
		{
			currentDisp = fullDisp.Substring(0,i);
			this.GetComponent<Text>().text = currentDisp;
			talkSound.Play();
			if (i == fullDisp.Length)
			{
				yield return new WaitForSeconds(delay + 5);
			}
			
			yield return new WaitForSeconds(delay);
		}
		this.GetComponent<Text>().text = "";
		this.gameObject.SetActive(false);
	}
}
