using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    private float TimeStamp;
    private bool Right;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Right)
        {

            transform.Translate(new Vector2(2.0f * Time.deltaTime, 0f));

            if (Time.time > TimeStamp)
            {
                TimeStamp = Time.time + 3.0f;
                Right = false;
            }
        }
        else
        {

            transform.Translate(new Vector2(-2.0f * Time.deltaTime, 0f));

            if (Time.time > TimeStamp)
            {
                TimeStamp = Time.time + 3.0f;
                Right = true;
            }
        }
	
	}
}
