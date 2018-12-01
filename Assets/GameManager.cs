using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public List<GameObject> pickups;
	public int index;
	public GameObject relic;
	public int counter;
	public Text t;
	[SerializeField]
	private bool activate;

	// Use this for initialization
	void Start () {
		activate = false;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		PickChecker ();

		if (activate == true) 
		{
			Debug.Log ("End Gate");
			relic.SetActive (false);
		}
		t.text = counter.ToString ();
	}

	void PickChecker()
	{
		
		//if (pickups [0].activeSelf == false && pickups [1].activeSelf == false && pickups [2].activeSelf == false) 
		if(counter==3)
			{
			activate = true;
			}
	}
}
