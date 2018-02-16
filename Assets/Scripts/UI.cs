using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public AudioSource bgsound;
    public AudioSource beatsound;

    float bpm = 168;
    int clapperbeat = 4;    

    float bgtime;
    int bgbeat;

    int prevbeat = -1;
    // Use this for initialization
    void Start () {

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
    }

    void Action_beat()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();
        cube.transform.position = new Vector3(0, 0, 0);
        cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }
}