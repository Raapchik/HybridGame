using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public List<GameObject> spike;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player" || col.tag == "Crate") 
		{
			Destroy (this.gameObject); // Remove this Code....................

			if (Input.GetKeyDown (KeyCode.E)) {
				foreach (GameObject i in spike) {	
					//i.SetActive (false);
					i.GetComponent<SpriteRenderer>().color=Color.red;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player" || col.tag == "Crate") 
		{

			foreach (GameObject i in spike) 
			{	
			//	i.SetActive (true);
			}
		}
	}
}
