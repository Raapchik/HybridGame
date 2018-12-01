using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour {

	public float speed,angle;

	public bool counterL,counterR;
	private PlayerController pc;

	public GameObject player;

	// Use this for initialization
	void Start () {
		counterL = false;
		pc = player.GetComponent<PlayerController> ();
	//	angle = 0;
	}
	
	// Update is called once per frame
	void Update () {

	//	transform.Rotate (new Vector3 (0, 0, 10*Time.deltaTime));

		if (Input.GetKeyDown (KeyCode.LeftArrow) && !counterL) 
		{
		//	angle = -90;
			//StartCoroutine (Rotatator(-90));	
			angle=transform.rotation.eulerAngles.z+90;
			if (angle > 350)
				angle = 0;
			counterL = true;
			StartCoroutine(ContinuousRotationL());
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && !counterR	) 
		{
			//angle = 90;
			//StartCoroutine (Rot (90));	
			//StartCoroutine (Rotatator(90));	
			angle=transform.rotation.eulerAngles.z-90;
			//if (angle > 350)
				//angle = 0;
			//angle=90;

			// Jugadd.......

//			if (angle == 0) {
//				Debug.Log("Set value to : 0 First");
//				angle = 90;
//			} else if (Mathf.Abs (angle) - 90 < 1f) {
//				Debug.Log("Set value to : 180");
//				angle = -180;
//			}else if ( Mathf.Abs (angle) - 180 < 1f) {
//				Debug.Log("Set value to : 270");
//				angle = -270;
//			}else if (Mathf.Abs (angle)  - 270 < 1f) {
//				angle = 0;
//				Debug.Log("Set value to : 0");
//			}






			counterR = true;
			StartCoroutine(ContinuousRotationR());
		}

		// Resolve.....

		if(Mathf.Abs(Mathf.Abs(angle)-transform.rotation.eulerAngles.z)<1f)
		{
			counterL=false;
		}

		if(Mathf.Abs(Mathf.Abs(angle)-Mathf.Abs( transform.rotation.eulerAngles.z))<1f)
		{
			counterR=false;
		}

//		if (angle - Mathf.Abs (transform.rotation.eulerAngles.z) < 1f) 
//		{
//			counter = false;
//		}


	}
//
//	IEnumerator Rot(float angle)
//	{
//		counter = true;
//		//StopAllCoroutines ();
//		float rot = 0;
//		float tarRot=transform.rotation.eulerAngles.z+angle;
//
//		Vector3 rota = transform.rotation.eulerAngles;
//		//while (rot <= angle-0.01f) 
//		while(Mathf.Abs(rot)<=Mathf.Abs( angle)-0.01f)
//		{
//			Debug.Log ("Rotatin.........");
//
//		//	rot += Time.deltaTime * speed;
//			rot=Mathf.LerpAngle(rot,angle,0.1f);
//			rota = transform.rotation.eulerAngles;
//			//rota.z += Time.deltaTime * speed; 
//			rota.z=Mathf.LerpAngle(rota.z,tarRot,0.1f);
//
//			//transform.rotation = Quaternion.Euler (rota);
//
//			transform.Rotate (rota);
//
//			yield return null;
//		}
//
//		counter = false;
//		transform.rotation = Quaternion.Euler (new Vector3 (0,0,tarRot));
//	}

	public Vector3 dir;

//	IEnumerator Rotatator(float angle)
//	{
//		counter = true;
//		float tarAngle=transform.rotation.eulerAngles.z+angle;
//
//		int dir = 1;
//	
//		float delta=0, update=transform.rotation.eulerAngles.z;
//
//		if (angle < 0) 
//		{
//			dir = -1;
//		}
//		Debug.Log (tarAngle+" Space "+transform.rotation.eulerAngles.z+" Space "+angle);
//
//		while(delta<Mathf.Abs( angle))	
//		{
//			
//			transform.Rotate (new Vector3 (0, 0, dir * speed * Time.deltaTime));
//			Debug.Log (update);
//			delta += Mathf.Abs( Mathf.Abs( transform.rotation.eulerAngles.z) - Mathf.Abs( update));
//			Debug.Log ("Inne r  "+Mathf.Abs( Mathf.Abs( transform.rotation.eulerAngles.z) - Mathf.Abs( update)));
//			update=transform.rotation.eulerAngles.z;
//
//			yield return  null;
//		}
//
//		transform.rotation = Quaternion.Euler (new Vector3 (0,0,tarAngle));
//		counter = false;
//
//	}

	IEnumerator ContinuousRotationL ()
	{
		Debug.Log ("Outside");
		while(counterL){
		//	Debug.Log (transform.rotation.eulerAngles.z);
			transform.Rotate(Vector3.forward,5);
			//transform.RotateAround (Vector3.zero, Vector3.forward, 10);
			yield return new WaitForSeconds (0.01f);

		}
		counterL = true;

	}

	IEnumerator ContinuousRotationR ()
	{
		
		Debug.Log ("Outside");
		while(counterR){
			//Debug.Log (Mathf.Abs(Mathf.Abs(angle)-Mathf.Abs( transform.rotation.eulerAngles.z)));
		//	Debug.Log (transform.rotation.eulerAngles.z);
			transform.Rotate(Vector3.forward,-10);
			//transform.RotateAround (Vector3.zero, Vector3.forward, 10);
			yield return new WaitForSeconds (0.01f);

		}
		counterR = true;
	}
}
