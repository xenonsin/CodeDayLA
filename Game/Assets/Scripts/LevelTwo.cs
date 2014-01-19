using UnityEngine;
using System.Collections;

public class LevelTwo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 200));

        GUI.Label(new Rect(0, 0, 250, 200), "Some things only exist in the light.");



        GUI.EndGroup();
    }
}
