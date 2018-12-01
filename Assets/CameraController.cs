using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			SceneManager.LoadScene (0);
		}

		//transform.position = Vector3.Lerp (transform.position+new Vector3(0,0,-10), player.transform.position+new Vector3(0,0,-10),speed);  //Here...

		transform.position = Vector3.Lerp (transform.position, player.transform.position+new Vector3(0,5,-10),speed);
	}
}
