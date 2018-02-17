using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public AudioSource bgsound;
    public AudioSource beatsound;

    public int score;

    float bpm = 168;
    int clapperbeat = 4;    

    float bgtime;
    int bgbeat;

    int prevbeat = -1;

    public Text text;
    
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bgsound.Stop();
            bgsound.Play();
        }
        // Debug.Log(bgsound.time);
        bgtime = bgsound.time;
        bgbeat = (int)(bgtime * bpm / (60 * clapperbeat));

        if (bgbeat > prevbeat)
        {
            beatsound.Play();
            prevbeat = bgbeat;
            Action_beat();
        }
        */
        text.text = "Score: " + score;

    }

    void Action_beat()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();
        cube.transform.position = new Vector3(0, 0, 0);
        cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}