using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public GameManager gm;
	public ParticleSystem ps;
	public Animator anim;

	void OnTriggerEnter(Collider col)
	{
		//ps.Play ();

		this.gameObject.SetActive (false);
		col.gameObject.SetActive (false);
		anim.SetBool ("Ender", true);
		Invoke ("LoadNextScene", 1);
	}

	void LoadNextScene()
	{
		SceneManager.LoadSceneAsync (gm.index+1);
	}
}
