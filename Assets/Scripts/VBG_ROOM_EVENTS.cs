using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBG_ROOM_EVENTS : MonoBehaviour
{
	public GameObject player; //Reference of the player Object
	public GameObject TV; //Reference of the TV object
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
		
    }
	void TVCollision()
	{
		/*
		if(player.GetComponent<VGB_Script>().CollisionCheck())
		{
		}
		*/
	}
    // Update is called once per frame
    void Update()
    {
		TVCollision();
    }
}
