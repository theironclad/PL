using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load requested for : " + name);
		SceneManager.LoadScene (name);
	}

	public void ReturnToTitle(){
		Debug.Log ("Request to return to title screen.");
		SceneManager.LoadScene ("Start");
	}

	public void QuitGame(){
		Debug.Log ("Request to quit");
		Application.Quit ();
	}
}
