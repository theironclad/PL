using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class AddCard : MonoBehaviour {

	public GameObject cardPrefab;
	public Transform cardParent = null;
	public GameObject cardToAdd;

	public int maxCards;

	public string cardName;

	public CardInventory database;
	public String cardNameFromDB;

	public SpriteRenderer sr;

	public PoosButton poos;


	// Use this for initialization
	void Start () {
		maxCards = 16;
		//cardParent = this.transform.parent;
		Debug.Log (this);
		//cardPrefab = (GameObject)Resources.Load ("Prefabs/Minion_Image");
		//cardToAdd = (GameObject)Resources.Load ("Prefabs/Minion_Image");
		//database = FindByName ("GameController").GetComponent(typeof(CardInventory)) as CardInventory;
		//cardToAdd = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddCardToParent(String name)
	{	
		
		//Make an array of text elements, this will be the card's text elements
		Text[] text;
		Image[] cardImage;

		//Get Card Item Presets
		Card preset = database.itemPresets[name]; // Get the preset

		//Set CardParent to a dropzone
		cardParent = this.transform.parent;
		Debug.Log (cardParent);

		//If there's room in the card parent, checking max
		if (cardParent.transform.childCount <= maxCards) {

			//Instantiate a card prefab
			cardToAdd = Instantiate(cardPrefab, cardParent.transform.position, Quaternion.identity) as GameObject;
			cardToAdd.name = name;
			Debug.Log ("cardToAdd's transform : " + cardToAdd.transform);
			//Set the new card's parent to CardParent
			cardToAdd.transform.SetParent (cardParent);

			//Set text array to all text components in children
			text = cardToAdd.GetComponentsInChildren <Text> ();

			//Populate image array. Set Card Sprite
			cardImage = cardToAdd.GetComponentsInChildren <Image> ();
			cardImage [1].sprite = Resources.Load <Sprite>("Sprites/heart");

			//Assign values to each element in the text array from dictionary definitions of item added.
			text [0].text = preset.name;
			text [1].text = "Count +" + 1;
			text [2].text = "Level + " + preset.level;
			text [3].text = "Cost : " + preset.cost;

			//Set text items in card to stuff from database entry

		}

	}

	//TODO : Make Purchase function. Should check cost of the clicked card against currentPoos
	public void Purchase()
	{
		
	}

	public GameObject FindByName(string child){
		
		Transform[] ts = cardToAdd.gameObject.transform.GetComponentsInChildren <Transform> (true);
		foreach (Transform t in ts) {
			Debug.Log ("For Each Loop : " + t.name);
			Debug.Log (ts);
			if (t.name == child) {
				Debug.Log (child);
				t.GetChild (4);
				Debug.Log ("Transform Name is : " + t.name);
				Debug.Log (t.GetChild (4));
				return t.gameObject;
			}
			return t.gameObject;
		}
		return null;
	}

}
