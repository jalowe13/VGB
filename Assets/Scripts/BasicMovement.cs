using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
	string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); //Current Script
    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    public Sprite[] gaming;
    public Sprite[] sit;
    public Sprite[] gaming_idle;


    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        //player = this.parent;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void idleCheck()
    {
        if (!Input.anyKeyDown) // Checking for Any Key being down for idle animation
        {
            for (int i = 0; i < 2; i++)
            {
                spriteRenderer.sprite = idle[i];
            }
        }
    }

    private void checkIdle()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("I want to sit");
            for (int i = 0; i < sit.Length; i++)
            {
                spriteRenderer.sprite = sit[i];
            }
            spriteRenderer.sprite = sit[sit.Length];
            player.GetComponent<VGB_Script>().checkSitting(true, true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("I will now stand");
            for (int i = sit.Length; i > -1; i++)
            {
                spriteRenderer.sprite = sit[i];
            }
            player.GetComponent<VGB_Script>().checkSitting(true, false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        //Check for Jump
        if (onGround() && Input.GetKeyDown(KeyCode.Space))
        {
            float jump_vel = 5f;
            rigidbody2d.velocity = Vector2.up * jump_vel;
        }

        idleCheck();
        checkIdle();



        //Horizontal X Direction Movement


        // Getting the Current component X and Y
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));


        //Making a new Vector of movement for that component

        Vector3 horizonal = new Vector3(Input.GetAxis("Horizontal")*2, 0.0f, 0.0f);


        //Moving that object
        transform.position = transform.position + horizonal * Time.deltaTime;

        //Vertical Movement Key
        //animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        //Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        //transform.position = transform.position + vertical * Time.deltaTime;

    }


    bool onGround()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down ,.1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }
}
