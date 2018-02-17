using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public enum ShapeType
    {
        CIRCLE,
        SQUARE,
        //STAR
        TRIANGLE,
    }

    public enum ColorType
    {
        RED,
        //GREEN,
        BLUE,
        YELLOW
    }

    public ShapeType shapeType;
    public ColorType color;

    SpriteRenderer sr;
    Sprite[] sprites;

	// Use this for initialization
	void Start () {
        sprites = Resources.LoadAll<Sprite>("Shape");

        sr = GetComponent<SpriteRenderer>();
        shapeType = (ShapeType)Random.Range(0, 3);
        color = (ColorType)Random.Range(0, 3);
        sr.sprite = sprites[(int)shapeType];
        switch (color)
        {
            case ColorType.RED:
                sr.color = Color.HSVToRGB(0, 0.5f, 1f);
                break;
            case ColorType.BLUE:
                sr.color = Color.HSVToRGB(220f/360f, 0.5f, 1f);
                break;
            /*
            case ColorType.GREEN:
                sr.color = Color.HSVToRGB(130f/360f, 0.5f, 1f);
                break;
                */
            case ColorType.YELLOW:
                sr.color = Color.HSVToRGB(60f/360f, 0.5f, 1f);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
