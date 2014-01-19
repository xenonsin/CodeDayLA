using UnityEngine;
using System.Collections;

public class WorldTransition : MonoBehaviour {

    public static bool white = true;
    public static int level = 1;

    public GameObject[] whiteGOS;
    public GameObject[] blackGOS;
    

	// Use this for initialization
	void Start () {

        whiteGOS = GameObject.FindGameObjectsWithTag("White");
        blackGOS = GameObject.FindGameObjectsWithTag("Black");

        /*foreach (var go in blackGOS)
            go.renderer.material.color = Color.black;*/
	
	}
	
	// Update is called once per frame
	void Update () {

        

        if (white)
        {
            foreach (var go in whiteGOS)
            {
                if (go != null)
                go.SetActive(true);

            }

            foreach (var go in blackGOS)
            {
                if (go != null)
                go.SetActive(false);
       
            }

        }
        else
        {
            foreach (var go in whiteGOS)
            {
                if (go != null)
                go.SetActive(false);

            }

            foreach (var go in blackGOS)
            {
                if(go != null)
                go.SetActive(true);

            }
        }
	
	}
}
