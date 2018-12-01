using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

//	public float speed,jumpForce;
//	private Rigidbody2D rb;
//
//	// Use this for initialization
//	void Start () {
//		rb = GetComponent<Rigidbody2D> ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//		if(Input.GetKey(KeyCode.A))
//			{
//			//transform.Translate(Vector2.left*speed*Time.deltaTime);
//			rb.velocity=Vector2.left*speed*Time.deltaTime;
//			}
//
//		if(Input.GetKey(KeyCode.D))
//		{
//			//transform.Translate(Vector2.right*speed*Time.deltaTime);
//		}
//
//		if(Input.GetKey(KeyCode.Space))
//		{
//			rb.AddForce (Vector2.up * jumpForce*Time.deltaTime	);
//		}
		




	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public AudioSource aud;
	public AudioClip j, p;

	[SerializeField]
	private bool grounded = false;
//	private Animator anim;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Awake () 
	{
	//	anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
			aud.PlayOneShot (j);
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");

	//	anim.SetFloat("Speed", Mathf.Abs(h));

		// Before.......

		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		// After.......

		if (Input.GetKey(KeyCode.A) && grounded) {
			Debug.Log ("Left");
			transform.Translate (Vector2.left * maxSpeed*Time.deltaTime);
		} 


		if (Input.GetKey(KeyCode.D) && grounded) {
			Debug.Log ("Right");
			transform.Translate (Vector2.right * maxSpeed * Time.deltaTime);
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) 
		{
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		
		}

		// Air......

		if (Input.GetKey(KeyCode.A) && !grounded) {
			Debug.Log ("Left");
			transform.Translate (Vector2.left * maxSpeed/2*Time.deltaTime);
		} 

		if (Input.GetKey(KeyCode.D) && !grounded) {
			Debug.Log ("Right");
			transform.Translate (Vector2.right * maxSpeed/2 * Time.deltaTime);
		}

		// else if (h == 0) {
		//	rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		//}


		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump)
		{
		//	anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			Debug.Log ("Jumped");
			jump = false;
		}
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
