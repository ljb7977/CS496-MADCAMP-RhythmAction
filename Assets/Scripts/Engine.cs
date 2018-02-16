using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public float period;
    public Transform shape;
    private float nextTime = 0f;

    public int bpm = 130;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1080, 1920, true);
        period = 60f / bpm;
        Debug.Log(period);
        Debug.Log(Screen.width);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextTime)
        {
            nextTime += period;
            Transform left = Instantiate(shape, new Vector3(-1.7f, 6.4f), Quaternion.identity, transform);
            Transform right = Instantiate(shape, new Vector3(1.7f, 6.4f), Quaternion.identity, transform);
            BroadcastMessage("Move");
        }
	}
}
