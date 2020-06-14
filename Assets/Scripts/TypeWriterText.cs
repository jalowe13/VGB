using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterText : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Scrip
	public float delay = 0.1f; //Text Write Speed Delay
	public string fullDisp; //Full Line of Dialogue 
	public bool eventNotRunning;
	private string currentDisp; //Current Display of Dialogue 
	private AudioSource talkSound; //Sound to play every time a letter is typed

	

    // Start is called before the first frame update
    void Start()
    {
		//Debug.Log("[" + currentFile + "] " + "[Start]");
		eventNotRunning = true;
		talkSound = GetComponent<AudioSource>();
    }

	public void displayEvent()
	{
		//Debug.Log("[" + currentFile + "] " + "[displayEvent]");
		talkSound = GetComponent<AudioSource>();
		eventNotRunning = false;
        StartCoroutine(DisplayText());
		StopCoroutine(DisplayText());
		//Debug.Log("[" + currentFile + "] " + "event complete");
	}
	
    IEnumerator DisplayText()
	{
		for (int i = 0; i < fullDisp.Length; i++)
		{
			currentDisp = fullDisp.Substring(0,i);
			this.GetComponent<Text>().text = currentDisp;
			talkSound.Play();
			if (i == fullDisp.Length - 1)
			{
				//Debug.Log("[" + currentFile + "] " + "Reached End");
				yield return new WaitForSeconds(delay + 5);
			}
			
			yield return new WaitForSeconds(delay);
		}
		//Debug.Log("[" + currentFile + "] " + "Delay done IE");
		this.GetComponent<Text>().text = "";
		eventNotRunning = true;
		this.transform.parent.gameObject.SetActive(false);
	}
}
