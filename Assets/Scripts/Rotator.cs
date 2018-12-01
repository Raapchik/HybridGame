using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float angle,speed,angleToDo,timer,timeCount;

	public GameObject point,player;

	public bool counter;

	// Use this for initialization
	void Start () {
		angle = 90;
		angleToDo = 90;
		timer = 0.2f;
		counter = false;
	}

	// Update is called once per frame
	void Update () {

		if (counter == true) {
			timer -= Time.deltaTime;
		}

		if (timer < 0) {
			timer =0.2f;

			transform.RotateAround (point.transform.position, Vector3.forward, angle);
			//StartCoroutine(Rot());

			counter = false;
			}

//		if (counter == false) 
//		{
//			transform.RotateAround (point.transform.position, Vector3.forward, angleToDo);
//			if (angleToDo < angle) {
//				angleToDo++;
//			} else
//				counter = true;
//		}


		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			//Rot (transform);	
			counter=true;
			//StartCoroutine(Rot(transform));

			Debug.Log ("Rotated");
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			counter = true;
			angle = -90; // Reverse the values
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			counter = true;
			angle = 90;  // Reverse the values
		}



		if (angleToDo < angle) 
		{
			transform.Rotate (Vector2.zero);
		}
		
	}

	IEnumerator Rot(float a)
	{
		angle += 90;

		//while (Mathf.Abs(transform.rotation.z - angle) > 2) 
		while(angleToDo<angle);
		{
			Debug.Log ("Corutine");
			//transform.RotateAround (new Vector3 (0, 0, speed));
			//transform.RotateAround (point.transform.position, Vector3.forward, speed);
			Debug.Log ("Re-Rotated");
		}
		yield return new WaitForSeconds (1f);
	}
}
