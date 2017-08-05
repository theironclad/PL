using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowText : MonoBehaviour {

	public float timer = 0.0f;
	public Text rainbowTarget;
	public PoosBehavior pb;
	public Animator rt;

	void Start()
	{
		pb = GameObject.FindGameObjectWithTag ("Poos").GetComponent <PoosBehavior>();
		rt = rainbowTarget.GetComponent <Animator> ();
	}

	void Update () {
		ChangeColor ();
	}

	public void ChangeColor()
	{
		if (pb.Affordable () == true) {
			rt.enabled = true;
		}else{
			rt.enabled = false;
			rainbowTarget.color = new Color(255.0f,255.0f,255.0f,1.0f);
		}
	}
}
