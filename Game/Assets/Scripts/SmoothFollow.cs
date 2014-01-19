using UnityEngine;
using System.Collections;



public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 2.0f;
    public new Transform transform;
    public Vector3 cameraOffset;

    private CharacterController2D _playerController;

    //public float dampTime = 0.15f;
    //private Vector3 velocity = Vector3.zero;
    //public Transform target;

    void Awake()
    {
        transform = gameObject.transform;
        _playerController = target.GetComponent<CharacterController2D>();
    }




    // Update is called once per frame

    /*
    void Update () 
    {
       if (target)
       {
         Vector3 point = camera.WorldToViewportPoint(target.position);
         Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
         Vector3 destination = transform.position + delta;
         transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
       }
 
    }*/

    public void LateUpdate()
    {
        if (_playerController == null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position - cameraOffset, followSpeed * Time.deltaTime);
            return;
        }

        if (_playerController.velocity.x > 0)
        {
            transform.position = Vector3.Lerp(transform.position, target.position - cameraOffset, followSpeed * Time.deltaTime);
        }
        else
        {
            var leftOffset = cameraOffset;
            leftOffset.x *= -1;
            transform.position = Vector3.Lerp(transform.position, target.position - leftOffset, followSpeed * Time.deltaTime);
        }
    }

}