using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour {

	public int currentStage;
	public int nextMilestone;
	public Text currentPoos; 
	public Click poos;

	public Text cStageText;
	public Text nMilestoneText;

	// Use this for initialization
	void Start () {
		poos = GameObject.FindGameObjectWithTag ("CardInventory").GetComponent <Click>();
		nextMilestone = 2;
		currentStage = 0;
		currentPoos = poos.currentPoos;
		cStageText = GameObject.FindGameObjectWithTag ("StageDisplay").GetComponent <Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
