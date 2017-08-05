using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoosPerSecond : MonoBehaviour {

	public Text ppsDisplay;
	public Click poosButton;
	public PrestigeController prestigeController;
	public PoosBehavior[] poosArray;
	public int prestigeBonus;

	void Start(){
	//	StartCoroutine (AutoTick ());
	}

	void Update(){
		prestigeBonus = Mathf.RoundToInt (prestigeController.prestigeBonus);
		ppsDisplay.text = GetPoosPerSec () + " Poos / Sec";
		poosArray = GameObject.FindGameObjectWithTag ("MinionsPanel").GetComponentsInChildren <PoosBehavior> ();

	}

	public int GetPoosPerSec ()
	{
		int tick = 0;

		foreach (PoosBehavior items in poosArray) {
			if (prestigeBonus > 0) {
				tick += (items.iCount * items.tickValue) * prestigeBonus;
			} else {
				tick += items.iCount * items.tickValue;
				Debug.Log (tick);
			}
		}
		return tick;
	}
	public void AutoPoosPerSec(){
		poosButton.poos += GetPoosPerSec ();
		poosButton.allTimePoos += GetPoosPerSec ();
	}
}
