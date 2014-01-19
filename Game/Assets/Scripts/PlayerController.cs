using UnityEngine;
using System.Collections;


public class PlayerController: MonoBehaviour
{
	// movement config
	public float gravity = -15.0f;
	public float runSpeed = 4.0f;
	public float groundDamping = 20.0f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5.0f;
	public float jumpHeight = 2.0f;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

    private float jumpCount = 0;



	void Awake()
	{
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();
		_controller.onControllerCollidedEvent += onControllerCollider;
	}


	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;

		if( _controller.isGrounded )
        {
            jumpCount = 0;
			_velocity.y = 0;
        }

        //Left and Right Movement
        if (Input.GetAxis("Horizontal") < 0)
		{
            //Checks if facing right. If so, flip sprite.
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			if( _controller.isGrounded )
				_animator.Play(Animator.StringToHash( "Walk" ) );
		}
        else if (Input.GetAxis("Horizontal") > 0)
		{
            //Checks if facing left. If so, flip sprite.
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Walk" ) );
		}
		else
		{

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Idle" ) );
		}


		// we can only jump whilst grounded
        if (_controller.isGrounded && Input.GetKeyDown("w"))
		{
            jumpCount++;
            _velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity );

			//_animator.Play( Animator.StringToHash( "Jump" ) );
		}

        //short hop
        if (!_controller.isGrounded && Input.GetKeyUp("w"))
        {
            _velocity.y /= 2;
        }


        //Fast Fall
        if (!_controller.isGrounded && Input.GetAxis("Vertical") < 0)
        {
            _velocity.y = -Mathf.Sqrt(2f * jumpHeight * -gravity);
        }

		// apply horizontal speed smoothing it
        float smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        _velocity.x = Mathf.Lerp(_velocity.x, Input.GetAxis("Horizontal") * runSpeed, Time.deltaTime * smoothedMovementFactor);

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		_controller.move( _velocity * Time.deltaTime );

        if (Input.GetKeyDown("k"))
        {
            if (WorldTransition.white)
                WorldTransition.white = false;
            else
                WorldTransition.white = true;
        }
    }

    void onCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Moveable")
        {
            if (_velocity.x > 0.3)
                c.rigidbody.AddForce(new Vector2 (3, 0));
            if (_velocity.x < -0.3)
                c.rigidbody.AddForce(new Vector2 (-1, 0));
        }
    }
}


    
