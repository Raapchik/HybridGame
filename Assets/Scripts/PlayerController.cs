using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed,jumpForce;
	public GameObject play;
	public GameObject cam;
	public AudioSource aud;
	public AudioClip j, p;

//	public Animator anim;

	public bool grounded = false;
	public Transform groundCheck;
	[SerializeField]
	LayerMask lm;
	[HideInInspector] public bool jump = false;
	[SerializeField,Range(0,1)]
	float ray_size;

	//public List<GameObject> spike;

	private Rigidbody rb;             // Here..
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();  // Here..
		grounded=true;
		//inst.PositionInfluence = new Vector3 (0.15,0.15,0.15);
		//inst.RotationInfluence =new Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () 
	{
	//	PlayAnimation ();

		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));   // Here..

		//grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		 //grounded = Physics.Raycast(transform.position,Vector3.down,1<<LayerMask.NameToLayer("Ground"));
	RaycastHit hit;
	//
		grounded = Physics.Raycast(transform.position,-transform.up,out hit,ray_size,lm);
	//	Debug.Log (hit.collider);
	//	Debug.Log (grounded);

		Debug.DrawRay (transform.position,-transform.up*ray_size,Color.red);

		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
			//cs.Shake (inst);
			aud.PlayOneShot(j);
		}



		if (Input.GetKey (KeyCode.A)) 
		{
			//transform.Translate (Vector2.left * speed * Time.deltaTime);
			//if(rb.bodyType!=RigidbodyType2D.Static)                    // Here..
			if(rb.isKinematic==false)
				rb.velocity=new Vector2(-speed*Time.deltaTime,rb.velocity.y);
			//play.transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			//transform.Translate (Vector2.right * speed * Time.deltaTime);
			//if(rb.bodyType!=RigidbodyType2D.Static)                                         // Here..
			if(rb.isKinematic==false)
			rb.velocity=new Vector2(speed*Time.deltaTime,rb.velocity.y);
			//play.transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) 
		{
			rb.velocity = new Vector2 (0,rb.velocity.y);
		}

		//if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) 
		if(jump)
		{
			rb.AddForce (Vector2.up * jumpForce);
			Debug.Log ("Jumped");
			jump = false;

		}

		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene (0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Button") 
		{
//			foreach (GameObject i in spike) 
//			{
//				i.SetActive (false);
//			}
		}

		if (col.gameObject.tag == "Spikes") 
		{
			SceneManager.LoadScene (0);
		}
	}


	void PlayAnimation()
	{
//		if(rb.velocity.y>0)
//			anim.SetBool("Going_Up",true);
//		else
//			anim.SetBool("Going_Up",false);
//
//		if(rb.velocity.y<0)
//			anim.SetBool("Going_Down",true);
//		else
//			anim.SetBool("Going_Down",false);
//
//		if (rb.velocity.x > 0 || rb.velocity.x < 0) 
//			anim.SetBool ("Walk_L",true);
//		else
//			anim.SetBool ("Walk_L",false);

	}
}
