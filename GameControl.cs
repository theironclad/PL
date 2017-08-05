using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {


	public static GameControl control;

	public Click poosButton;

	public EnemyBehavior currentEnemy;
	public Text enemyHDisplay;

	//public float poos;

	void Awake (){
		if (control==null){
			DontDestroyOnLoad (gameObject);
			control = this;
		}else if(control !=this){
			Destroy (gameObject);
		}
	}

	void Start () {
		
		enemyHDisplay = GameObject.FindGameObjectWithTag ("EnemyHealth").GetComponent <Text> ();
		Debug.Log (currentEnemy);
		Debug.Log (enemyHDisplay);
	}
	
	// Update is called once per frame
	void Update () {
		currentEnemy = GameObject.FindGameObjectWithTag ("Enemy").GetComponent <EnemyBehavior> ();
		enemyHDisplay.text = "ENEMY HEALTH : " + currentEnemy.eHealth.ToString ();
	}

	/*void OnGUI(){
		GUI.Label (new Rect(10,10,100,30), "Poos : " + poosButton.poos);
	}*/


	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
		PlayerData data = new PlayerData ();
		data.poos = poosButton.poos;
		data.ppc = poosButton.poosPerClick;
		Debug.Log ("Saved");

		bf.Serialize (file,data);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			poosButton.poos = data.poos;
			poosButton.poosPerClick = Mathf.RoundToInt (data.ppc);
			Debug.Log("Loaded");
		}
	}
}

[Serializable]
class PlayerData{
	public float poos;
	public float ppc;
}