using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public GameManager gm;
	private AudioSource aud;
	public AudioClip a;

	void Start()
	{
		aud = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player") 
		{
			gm.counter++;
			aud.PlayOneShot (a);
			this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
