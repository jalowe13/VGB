using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	GameObject OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log(collision.gameObject);
		return collision.gameObject;
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
