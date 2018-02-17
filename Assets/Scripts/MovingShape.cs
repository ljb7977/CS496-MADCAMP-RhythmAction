using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShape : Shape {

    float startTime, moveTime, y_velocity;
    bool isMoving = false;

    Rigidbody2D rb;

    public UI UIComponent;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        moveTime = transform.parent.GetComponent<Engine>().period / 3f;
        y_velocity = 1.4f / moveTime;
        UIComponent = GameObject.Find("Canvas").GetComponent<UI>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            if (Time.time - startTime > moveTime)
            {
                isMoving = false;
                rb.velocity = new Vector2(0, 0);
            }
        }

        if (rb.position.y < -6)
        {
            UIComponent.score -= 10;
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        rb.velocity = new Vector2(0, -y_velocity);
        startTime = Time.time;
        isMoving = true;
    }
}
