using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public BoxCollider2D collideDetect;
	private AudioSource source;
	[SerializeField] private Sprite openLeftImage,openRightImage,closedImage;
	
	
    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>(); // Getting the audio for opening door
    }
	

	IEnumerator SecondDelay(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Debug.Log("Closing");
			spriteRenderer.sprite = closedImage;
			collideDetect.enabled = true;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Enter");
		if (collision.gameObject.tag == "Player")
		{
			source.Play();
			spriteRenderer.sprite = openLeftImage;
			collideDetect.enabled = false;
			
		}
	}
	void OnCollisionExit2D(Collision2D collision)
	{
			StartCoroutine(SecondDelay(2));
	}
	
	void OnCollisionStay2D(Collision2D collision)
	{
	if (collision.gameObject.tag == "Player")
		{
			spriteRenderer.sprite = openLeftImage;
			collideDetect.enabled = false;
			
		}
	}


    // Update is called once per frame
    void Update()
    {
		
    }
}
