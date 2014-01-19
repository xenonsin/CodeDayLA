using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    
  

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!WorldTransition.white)
            renderer.material.color = Color.black;
        else
            renderer.material.color = Color.white;
	
	}
}
