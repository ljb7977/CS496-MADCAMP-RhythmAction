using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public float period;
    public Transform shape;
    private float nextTime = 0f;

    public AudioSource bgsound;
    public int bpm;
    
    public LayerMask buttonLayer;

    // Use this for initialization
    void Start () {
        
        Application.targetFrameRate = 60;
        Screen.SetResolution(1080, 1920, true);
        period = 60f / bpm;
        bgsound.PlayDelayed(3);
	}

    // Update is called once per frame
    void Update() {
        if (Time.time > nextTime)
        {
            nextTime += period;
            Instantiate(shape, new Vector3(-1.7f, 6.3f), Quaternion.identity, transform);
            Instantiate(shape, new Vector3(1.7f, 6.3f), Quaternion.identity, transform);
            BroadcastMessage("Move");
        }
        /*
        foreach (Touch touch in Input.touches)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, buttonLayer))
            {
                GameObject recipient = hit.transform.gameObject;
                if (touch.phase == TouchPhase.Began)
                {
                    recipient.SendMessage("OnTouch", hit.point);
                }
            }
        }*/
    }
}
