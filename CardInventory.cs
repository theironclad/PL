using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInventory : MonoBehaviour {

	public List<Card> items = new List<Card>();
	public Dictionary<string, Card> itemPresets = new Dictionary<string, Card>();
	//public SpriteRenderer sr;
	//public Card preset;
	//public CardInventory inv = new CardInventory ();
	// Presets (Prototypes) are meant to be predefined instances that are later 
	// copied to actual instances for game use. Set these in your init,
	// like hardcoded, or from a file...

	void Start()
	{
		SetPreset ("Woobles", new Card("Woobles",2,1,1,1,1));
		SetPreset("Farts", new Card ("Farts", 11, 10000, 1, 9001, 10));
		SetPreset ("Toots", new Card("Toots", 1, 100, 1, 9002, 11));
		//itemPresets.Add ("Toots", new Card("Toots", 1, 100, 1, 9002, 11));


//		items.Add (itemPresets["Farts"]);
		AddNew ("Farts");	
		AddNew ("Toots");
		AddNew ("Woobles");
	}


	public void SetPreset(string name, Card preset)
	{
		itemPresets[name] = preset;
	}

	public Card AddNew(string name)
	{
		
		Card preset = itemPresets[name]; // Get the preset
		Card newItem = new Card(preset.name, preset.id, preset.cost, preset.level, preset.power, preset.speed);
		items.Add(newItem);
		return newItem;
	}

}


