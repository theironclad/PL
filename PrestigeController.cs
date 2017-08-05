using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestigeController : MonoBehaviour {

	public Click poosButton;
	public float prestigeNumber;
	public float prestigeBonus;
	public ItemManager[] items;
	public UpgradeManager[] upgrades;
	public int purchases = 0;

	/*public int TotalPurchases(){
		foreach(ItemManager item in items){
			purchases += 1;
		}
		foreach(UpgradeManager upgrade in upgrades){
			purchases +=1;
		}
		return purchases;
	}*/

	public void Prestige ()
	{
		poosButton.poos = 0;
		poosButton.poosPerClick = 0;
		prestigeNumber += 1;
		prestigeBonus = (1.05f * prestigeNumber);
		GameObject[] objects;
		objects = GameObject.FindGameObjectsWithTag ("Button");
		foreach (GameObject button in objects) {
			if (button.GetComponent<ItemManager>()) {
				button.GetComponent<ItemManager> ().count = 0;
				button.GetComponent<ItemManager>().cost = 0;
			}else if (button.GetComponent<UpgradeManager>()) {
				button.GetComponent<UpgradeManager>().level = 0;
				button.GetComponent<UpgradeManager>().cost = 0;
			}
		}
		Debug.Log ("Prestige Number : " + prestigeNumber 
				+ "\nPrestige Bonus : " + prestigeBonus 
				+ "\nPurchases : " + purchases);

	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
