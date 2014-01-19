using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private bool player = false;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        player = Physics2D.OverlapCircle(transform.localPosition, .5f, 1 << LayerMask.NameToLayer("Player"));

        if (player)
        {
            Player.lastCheckpoint = new Vector2(transform.position.x, transform.position.y);
            Destroy(this.gameObject);
        }

    }
}
