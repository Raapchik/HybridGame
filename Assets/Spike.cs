using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour {

	public GameManager gm;
	public Animator anim;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player") 
		{
			//gm.player.transform.position = gm.spawnPosition.transform.position;
			col.gameObject.SetActive(false);
			anim.SetBool ("Ender", true);
			Invoke ("LoadNextScene",1.1f);
		}
	}
	void LoadNextScene()
	{
		SceneManager.LoadScene(gm.index);
	}
}
