using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public int eHealth;
	//public int eHealthStart;

	public StageController sc;
	public AddEnemy addEnemy;

	// Use this for initialization
	void Start () {
		addEnemy = GameObject.FindGameObjectWithTag ("CardInventory").GetComponent <AddEnemy> ();
		sc = GameObject.FindGameObjectWithTag ("StageDisplay").GetComponent <StageController>();
		eHealth = sc.currentStage * 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (eHealth <= 0) {
			Destroy (this.gameObject);
			sc.currentStage++;
			Debug.Log (sc.currentStage);
			sc.cStageText.text = "Current Stage : " + sc.currentStage.ToString ();
			//addEnemy.AddEnemyToCanvas ();
		}
	}

}
