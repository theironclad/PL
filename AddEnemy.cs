using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour {

	public bool EnemyExist;
	public GameObject enemyToAdd;
	public GameObject enemyPrefab;
	public GameObject spawnPoint;
	public Transform enemyParent;

	public StageController sc;
	public GameControl gc;
	// Use this for initialization
	void Start () 
	{
		enemyParent = GameObject.FindGameObjectWithTag ("CameraCanvas").transform;
		sc = GameObject.FindGameObjectWithTag ("StageDisplay").GetComponent <StageController>();
		gc = GameObject.FindGameObjectWithTag ("CardInventory").GetComponent <GameControl>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.FindGameObjectWithTag ("Enemy"))
		{
			return;
		}else{
			//Add Enemy to Camera Canvas
			//AddEnemyToCanvas ();
			BossCheck ();
			Debug.Log(spawnPoint);
		}
	}

	public void AddEnemyToCanvas()
	{
		enemyToAdd = Instantiate (enemyPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
		enemyToAdd.name = enemyPrefab.name;
		enemyToAdd.transform.SetParent (enemyParent);
		enemyToAdd.GetComponent <EnemyBehavior>().eHealth = sc.currentStage * 100;
		gc.currentEnemy = enemyToAdd.GetComponent <EnemyBehavior> (); 
		Debug.Log (enemyToAdd.GetComponent <EnemyBehavior>().eHealth);
	}

	public void BossCheck()
	{
		if (sc.currentStage == sc.nextMilestone) {
			Debug.Log ("Milestone reached, setting prefab to Nurse1");
			enemyPrefab = Resources.Load ("Prefabs/Nurse1") as GameObject;
			AddEnemyToCanvas ();
		}else{
			Debug.Log ("Milestone not reached, adding normal enemy.");
			enemyPrefab = Resources.Load ("Prefabs/NursingHome1") as GameObject;
			AddEnemyToCanvas ();
		}
	}

}
