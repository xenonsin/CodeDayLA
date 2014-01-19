using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float gravity = 8.0f;
    private float startTime;
	private float endTime = 5.0f;
    private float TimeStamp;

    private bool Right;
  

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //StartCoroutine(move());

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
