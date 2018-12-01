using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour {

	public float angle,angleToDo,speed;
	public bool checker;
	public AudioSource aud,bgaud;
	public AudioClip a;


	private PlayerController pc;

	public GameObject point;

	// Use this for initialization
	void Start () 
	{
		//angleToDo = angle + 90;
		angle = transform.rotation.eulerAngles.z;
		pc = point.GetComponent<PlayerController> ();
		bgaud = GameObject.Find ("BG_muzik").GetComponent<AudioSource> ();
		aud = GameObject.Find ("GameManager").GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (aud == null) 
		{
			aud = GameObject.Find ("GameManager").GetComponent<AudioSource> ();
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && checker==false && pc.grounded)     // Invert Controls............
		{
			aud.PlayOneShot(a);
			angleToDo += 90;
			if (angleToDo > 350)
				angleToDo = 0;

			speed = Mathf.Abs (speed);
			Debug.Log ("Updated");
		}else
		angle = transform.rotation.eulerAngles.z;

		if (Input.GetKeyDown (KeyCode.LeftArrow) && checker==false && pc.grounded)     // Invert Controls............
		{
			aud.PlayOneShot(a);
//			if (angleToDo == 270)
//				angleToDo = 180;
//			
//
//			angleToDo += 270;
//			if (angleToDo > 350)
//				angleToDo = 0;

			if (angleToDo == 0) 
			{
				angleToDo = 270;
			}
			else if (angleToDo == 270) 
			{
				angleToDo = 180;
			}else if (angleToDo == 180) 
			{
				angleToDo = 90;
			}else if (angleToDo == 90) 
			{
				angleToDo = 0;
			}


			if(speed>0)
				speed = -speed;
			
			Debug.Log ("Updated");
		}else
			angle = transform.rotation.eulerAngles.z;


//		if (Mathf.Abs (angleToDo - angle) > 1f) {
//			checker = true;
//			transform.RotateAround (point.transform.position, Vector3.forward, speed);
//		} else
//			checker = false;

		Rotor ();

		if (checker)
			bgaud.Pause ();
		else
			bgaud.UnPause ();

	}

	void Rotor()
	{
		if (Mathf.Abs (angleToDo - angle) > 1f) {
			checker = true;
			// Pause Mid Air..
			//point.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;   // Here..
			point.GetComponent<Rigidbody>().isKinematic=true;
			//bgaud.Pause ();
			//aud.PlayOneShot(a);
			transform.RotateAround (point.transform.position, Vector3.forward, speed);
		} else {
			checker = false;
			//point.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;   // Here..
			point.GetComponent<Rigidbody>().isKinematic=false;
			//bgaud.Play();

		}
	}
}
