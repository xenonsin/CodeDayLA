using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool OneWay;
    private float _t;

    void Start()
    {
        startPosition = transform.position;
        //MoveDirection is Vector3 - usually a norm vector like (0,1,0)
        //which would cause the platform to move along the Y axis
        //endPosition = startPosition + new Vector2 (0, 2);
        //ColliderPlatform holds a collider that is not a trigger, as 
        //well as the mesh, and must move with the whole platform
        //ColliderPlatform.transform.parent = transform;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("hit");
            collision.transform.parent = transform;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            collision.transform.parent = null;
        }
    }
    void Update()
    {
        if (OneWay)
            _t += Time.deltaTime * 2.0f * .1f;
        else
            _t -= Time.deltaTime * 2.0f * .1f;
        transform.position = Vector3.Lerp(startPosition, endPosition, _t);

        _t = Mathf.Clamp(_t, 0.0f, 1.0f); //avoids platforms getting stuck

        if (transform.position == endPosition || transform.position == startPosition)
            OneWay = !OneWay;
    }
       

}
