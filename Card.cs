using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card {
	public string name;
	public int id;
	public int cost;
	public int level;
	public int power;
	public int speed;
	//public Sprite image;

	public Card(string newName, int newId, int newCost, int newLevel, int newPower, int newSpeed)
	{
		name = newName;
		id = newId;
		cost = newCost;
		level = newLevel;
		power = newPower;
		speed = newSpeed;	
	}
}
