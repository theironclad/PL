using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Text itemInfo;
	public Text itemCost;
	public Click poosButton;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	private float baseCost;
	public Color standard;
	public Color affordable;
	public Color disabled;
	private Slider _slider;
	public PrestigeController prestigeController;

	// Use this for initialization
	void Start () {
		baseCost = cost;
		_slider = GetComponentInChildren <Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		itemInfo.text = itemName + "\n Cost : " + cost + "\nPoos : " + tickValue + "/s";
		itemCost.text = "Cost : " +cost;

		_slider.value = poosButton.poos / cost * 100;

		if(poosButton.poos>=cost){
			GetComponent<Image> ().color = affordable;
		}else if(poosButton.poos<cost){
			GetComponent<Image> ().color = disabled;
		}else{
			GetComponent<Image> ().color = standard;
		}
	}

	public void PurchasedItem(){
		if (poosButton.poos >= cost) {
			poosButton.poos -= cost;
			count += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
			prestigeController.purchases += 1;
		}
	}
}
