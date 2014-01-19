using UnityEngine;
using System.Collections;

public class LevelOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 200));

        GUI.Label(new Rect(0, 0, 200, 200), "Turn the lights off with K!");

       

        GUI.EndGroup();
    }
}
