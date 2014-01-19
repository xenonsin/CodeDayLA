using UnityEngine;
using System.Collections;

public class FairyCamera : MonoBehaviour
{

    public GameObject target;

    public float threshold = 8.0f;

    // Use this for initialization
    void Start()
    {

        transform.position = target.transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector2.Distance(transform.position, target.transform.position);

        if (dist >= threshold)
            transform.position = Vector3.Slerp(transform.position, target.transform.position, Time.deltaTime);


    }
}
