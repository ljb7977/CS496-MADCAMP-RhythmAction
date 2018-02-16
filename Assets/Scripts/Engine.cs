using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    private float period = 0.5f;
    public Transform shape;
    private float nextTime = 0f;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1080, 1920, true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextTime)
        {
            Debug.Log(Time.time);
            Debug.Log(nextTime);
            nextTime += period;
            Transform left = Instantiate(shape, new Vector3(-2f, 6f), Quaternion.identity, transform);
            Transform right = Instantiate(shape, new Vector3(2f, 6f), Quaternion.identity, transform);
            BroadcastMessage("Move");
        }
	}
}
