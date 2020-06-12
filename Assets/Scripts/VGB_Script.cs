using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VGB_Script : MonoBehaviour
{
	public bool colliding;
	//private BoxCollider2D collideDetect;
    // Start is called before the first frame update
    void Start()
    {
        colliding = false;
    }
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "TV")
		{
		//Debug.Log(collision.gameObject);
		colliding = true;
		}
	}
	
		bool CollisionCheck()
	{
		return colliding;
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
	

	
}
