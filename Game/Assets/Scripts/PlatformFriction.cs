using UnityEngine;
using System.Collections;

public class PlatformFriction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D other){
        Debug.Log("ENTER");
        other.transform.parent = null;
        other.transform.parent = gameObject.transform; } 
    
    void OnTriggerExit2D (Collider2D other) {
        Debug.Log("EXIT");
        other.transform.parent = null; }
}
