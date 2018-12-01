using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 25; i++) 
		{
			for (int j = 0; j < 25; j++) 
			{
				 GameObject go= Instantiate (cube, new Vector3 (i, j, 0), Quaternion.identity);
				go.transform.SetParent (transform);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
