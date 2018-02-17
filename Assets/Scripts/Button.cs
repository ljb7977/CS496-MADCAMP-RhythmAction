using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public KeyCode push;

    public Shape collidingShape = null;
    public bool isColliding = false;
    public Shape standardShape;

    Animator animator;

    public UI UIComponent;

    public enum ButtonType
    {
        SHAPE,
        COLOR
    }

    public ButtonType buttonType;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        standardShape = GameObject.Find("StandardShape").GetComponent<Shape>();
        UIComponent = GameObject.Find("Canvas").GetComponent<UI>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(push))
        {
            animator.SetBool("ButtonPress", true);

            if(buttonType == ButtonType.SHAPE)
            {
                if (collidingShape != null && collidingShape.color == standardShape.color)
                {
                    Destroy(collidingShape.gameObject);
                    UIComponent.score += 10;
                }
                else
                {
                    UIComponent.score -= 100;
                    //gameOver;
                }
            }
            else if (buttonType == ButtonType.COLOR)
            {
                if (collidingShape != null && collidingShape.shapeType == standardShape.shapeType)
                {
                    Destroy(collidingShape.gameObject);
                    UIComponent.score += 10;
                }
                else
                {
                    UIComponent.score -= 100;
                    //gameOver;
                }
            }
        }

        if (Input.GetKeyUp(push))
        {
            animator.SetBool("ButtonPress", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shape"))
        {
            collidingShape = other.GetComponent<Shape>();
            isColliding = true;
        }
    }
}
