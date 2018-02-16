using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public enum ShapeType
    {
        CIRCLE,
        TRIANGLE,
        SQUARE,
        STAR
    }

    public enum ColorType
    {
        RED,
        GREEN,
        BLUE,
        YELLOW
    }

    public ShapeType shapeType;
    public ColorType color;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Sprite[] sprites;

    float startTime, moveTime=0.25f;
    bool isMoving = false;

	// Use this for initialization
	void Start () {
        float y = 6f;

        rb = GetComponent<Rigidbody2D>();
        //rb.MovePosition(new Vector2(transform.position.x, y));

        sprites = Resources.LoadAll<Sprite>("Shape");

        sr = GetComponent<SpriteRenderer>();
        shapeType = (ShapeType)Random.Range(0, 4);
        color = (ColorType)Random.Range(0, 4);
        sr.sprite = sprites[(int)shapeType];
        switch (color)
        {
            case ColorType.RED:
                sr.color = Color.HSVToRGB(0, 0.5f, 1f);
                break;
            case ColorType.BLUE:
                sr.color = Color.HSVToRGB(220f/360f, 0.5f, 1f);
                break;
            case ColorType.GREEN:
                sr.color = Color.HSVToRGB(130f/360f, 0.5f, 1f);
                break;
            case ColorType.YELLOW:
                sr.color = Color.HSVToRGB(60f/360f, 0.5f, 1f);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            if(Time.time-startTime > moveTime)
            {
                isMoving = false;
                rb.velocity = new Vector2(0, 0);
            }
        }

        if(rb.position.y < -6)
        {
            Destroy(gameObject);
        }
	}

    public void Move()
    {
        rb.velocity = new Vector2(0, -5f);
        startTime = Time.time;
        isMoving = true;
    }
}
