using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public Click poosButton;
	public UnityEngine.UI.Text itemInfo;
	public UnityEngine.UI.Text itemCost;
	public float cost;
	public int level = 0;
	public int poosPower;
	public string itemName; 
	private float baseCost;
	public Color standard;
	public Color affordable;
	public Color disabled;
	[SerializeField]
	private Slider _slider;

	void Start(){
		baseCost = cost;
		_slider = GetComponentInChildren <Slider> ();
	}

	void Update(){
//		itemInfo.text = itemName + " Level " + level + "\nCost : " + cost + "\nPower : " + poosPower;
//		itemCost.text = "Cost : " + cost;
//		_slider.value = poosButton.poos / cost * 100;
//
//
		/*
		if(poosButton.poos>=cost){
			GetComponent<Image> ().color = affordable;
		}else if(poosButton.poos<cost){
			GetComponent<Image> ().color = disabled;
		}else{
			GetComponent<Image> ().color = standard;
		}
		*/
	}

	public void PurchasedUpgrade(){
		if (poosButton.poos >= cost){
			poosButton.poos -= cost;
			level += 1;
			poosButton.poosPerClick += poosPower;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, level));

		}
	}


}
