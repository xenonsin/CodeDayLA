using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool normalDoor = false;
    private bool keyDoor = false;
    public static bool hasKey = false;
    

  

	// Use this for initialization
	void Start () {

        renderer.sortingLayerName = "Foreground";
        renderer.sortingOrder = 2;
            //.sortingLayerName = "Foreground";

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
            Application.LoadLevel("Level " + WorldTransition.level);
        }

        if (keyDoor && hasKey)
        {
            WorldTransition.level++;
            Application.LoadLevel("Level " + WorldTransition.level);
        }

        
	}

}
