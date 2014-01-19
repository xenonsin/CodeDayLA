using UnityEngine;
using System.Collections;

public class BoxReset : MonoBehaviour {

    public static Vector2 lastCheckpoint;

	// Use this for initialization
	void Start () {

        lastCheckpoint = new Vector2(transform.position.x, transform.position.y);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < -30)
        {
            //WorldTransition.white = true;
            transform.position = lastCheckpoint;
        }
	
	}
}
