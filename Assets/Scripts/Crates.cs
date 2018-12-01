using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour {

	public List<GameObject> spike;

	void OnTriggerEnter2D(Collider2D col)
	{
//		if (col.tag == "Button") 
//		{
//			foreach (GameObject i in spike) 
//			{
//				i.SetActive (false);
//			}
//		}

		if (col.tag == "Spikes") 
		{
			Destroy (this.gameObject);
		}
	}
}
