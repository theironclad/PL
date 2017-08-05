using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PoosBehavior : MonoBehaviour {

	public GameObject poosObj;
	public Text pName;
	public Text pLevel;
	public Text pCount;
	public Text pCost;
	public Text[] pTexts;
	public int iLevel;
	public int iCount;
	public int tickValue;
	public float currentCost;

	public Click poosClick;


	// Use this for initialization
	void Start () {
		pTexts = GetComponentsInChildren <Text> ();
		pName = pTexts [0];
		pLevel = pTexts [1];
		pCount = pTexts [2];
		pCost = pTexts [3];
		currentCost = 10;
		iLevel = 0;
		iCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool Affordable()
	{
		if (poosClick.poos < currentCost) {
			return false;
		}
		else
		{
			return true;
		}
	}

	public void BuyLevel()
	{
		if (Affordable () == true) 
		{
			GetComponent <Button>().interactable = true;
			iLevel++;
			poosClick.poos -= currentCost;
			pLevel.text = "Level : " + iLevel.ToString ();
			currentCost = currentCost * 1.5f;
			pCost.text = "Upgrade Cost : " + currentCost.ToString ();
		}
	}
}
