using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {
    public Text ppc;
    public Text currentPoos;
    public Text allPoos;
    public Text statsList;
    public float poos = 0;
    public float allTimePoos = 0;
	public int poosPerClick = 1;
	public PrestigeController prestigeController;
	public EnemyBehavior eBehavior = null;
	public PoosBehavior pBehavior;
	public PoosPerSecond ppsScript;

	void Start()
	{
		
	}

	void Update() {
		if (eBehavior == null) {
			eBehavior = GameObject.FindGameObjectWithTag ("Enemy").GetComponent <EnemyBehavior> ();
			StartCoroutine (AutoTick ());
		}
		string allPoos_Converted = CurrencyConverter.Instance.GetCurrencyIntoString(allTimePoos,false,false);
		currentPoos.text = "POOS! : " + CurrencyConverter.Instance.GetCurrencyIntoString (poos,false,false);
		allPoos.text = "\nALLTIME POOS! : " + allPoos_Converted 
					+ "\nALLTIME ITEMS! : " + prestigeController.purchases;		
		if (pBehavior.iLevel > 1) {
			poosPerClick = pBehavior.iLevel * 2;
		}
		ppc.text = poosPerClick + " Poos Per Click";
	}

	public void Clicked(){
		poos += poosPerClick;
		eBehavior.eHealth -= poosPerClick;
		eBehavior.eHealth -= ppsScript.GetPoosPerSec ();
		allTimePoos += poosPerClick;
		Debug.Log ("Clicked finished");
	}

	public void DevMode(){
		poos += 10000000000000000000;
	}

	public void AutoClick()
	{
		Debug.Log ("Calling Clicked from AutoClick");
		Clicked ();
		poos += ppsScript.GetPoosPerSec ();
		Debug.Log ("Clicked was called");
	}

	IEnumerator AutoTick(){
		while(true)
		{
			Debug.Log ("AutoTick is TRUE");
			AutoClick ();
			yield return new WaitForSeconds (1);
		}
	}
}