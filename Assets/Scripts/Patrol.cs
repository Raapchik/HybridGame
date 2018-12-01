using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

//	public float min=2f;
//	public float max=3f;
//	// Use this for initialization
//	void Start () {
//
//		min=transform.position.x;
//		max=transform.position.x+3;
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//
//		transform.position =new Vector3(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y, transform.position.z);
//
//	}


	public Transform pointB,pointA;

	public float t;

	IEnumerator Start()
	{
		//var pointA = transform.position;
		//var pointA
		while(true)
		{
			//yield return StartCoroutine(MoveObject(transform, pointA, pointB.position, 3.0f));
			//yield return StartCoroutine(MoveObject(transform, pointB.position, pointA, 3.0f));

			yield return StartCoroutine(MoveObject(transform, pointA.position, pointB.position,t));
			yield return StartCoroutine(MoveObject(transform, pointB.position, pointA.position,t));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}
}
