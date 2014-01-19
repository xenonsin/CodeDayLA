using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    private bool normalDoor = false;
    private bool keyDoor = false;
    public static bool hasKey = false;
    private bool platform = false;
    public static Vector2 lastCheckpoint;



	// Use this for initialization
	void Start () {

        lastCheckpoint = new Vector2(transform.position.x, transform.position.y);


	}
	
	// Update is called once per frame
	void Update () {
        if (!WorldTransition.white)
            renderer.material.color = Color.black;
        else
            renderer.material.color = Color.white;

        normalDoor = Physics2D.OverlapCircle(transform.localPosition, .5f, 1 << LayerMask.NameToLayer("Door"));

        keyDoor = Physics2D.OverlapCircle(transform.localPosition, .5f, 1 << LayerMask.NameToLayer("Key Door"));


        if (normalDoor)
        {
            WorldTransition.level++;

            if (Application.CanStreamedLevelBeLoaded("Level " + WorldTransition.level))
                 Application.LoadLevel("Level " + WorldTransition.level);
        }

        if (keyDoor && hasKey)
        {
            WorldTransition.level++;
            if (Application.CanStreamedLevelBeLoaded("Level " + WorldTransition.level))
                Application.LoadLevel("Level " + WorldTransition.level);
        }

        if (transform.position.y < -30)
        {
            WorldTransition.white = true;
            transform.position = lastCheckpoint;
        }

     
        
	}


}
