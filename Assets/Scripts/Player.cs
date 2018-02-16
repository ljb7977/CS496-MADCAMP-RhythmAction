using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum playerState
    {
        normal = 0,
        run,
        jump
    }

    public bool isRight;

    public Animator anim;
    public playerState state = playerState.normal;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode leftKey, rightKey;

    private Rigidbody2D theRB;
    public LayerMask whatIsGround;
    public float groundCheckRadius;

    public bool isGrounded;

    public AudioSource jumpAudio;

    public int clickCount;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        isRight = true;
        state = playerState.normal;
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = 0;

        bool jumping = false;

        if (Input.GetKey(leftKey))
        {
            xSpeed = -moveSpeed;
            isRight = false;
        }
        else if (Input.GetKey(rightKey))
        {
            xSpeed = moveSpeed;
            isRight = true;
        }

        if (isRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (jumping && isGrounded)
        {
            //jumpAudio.Play();
            theRB.velocity = new Vector2(xSpeed, jumpForce);
        }
        else
        {
            theRB.velocity = new Vector2(xSpeed, theRB.velocity.y);
        }

        isGrounded = Physics2D.Raycast(transform.position, new Vector2(0, -1), groundCheckRadius, whatIsGround);

        if (isGrounded)
        {
            if (theRB.velocity.x == 0)
                state = playerState.normal;
            else
                state = playerState.run;

            if (jumping)
                state = playerState.jump;
        }
        else
        {
            state = playerState.jump;
        }

        if (anim != null)
        {
            anim.SetInteger("playerState", (int)state);
        }
    }

    private void OnTriggerEnter(Collider item)
    {
        //print(other.tag);
        if (item.CompareTag("item"))
        {
            
        }
    }

    private void OnTriggerExit(Collider item)
    {
        if (item.CompareTag("item"))
        {

        }
    }
}
