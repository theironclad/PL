using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlide : MonoBehaviour {

	public Animator menuButtons_Panel;
	public Animator minions_Panel;
	public Animator items_Panel;
	public Animator menu_Panel;

	public void makeRoom (){

		if (items_Panel.GetBool ("isShifted")){
			items_Panel.SetBool ("isShifted",false);
			minions_Panel.SetBool ("isShifted",true);
		}else if (menuButtons_Panel.GetBool ("isShifted") || minions_Panel.GetBool ("isShifted")){
		closeMenu ();

		}else {			
			menuButtons_Panel.SetBool ("isShifted",true);
			minions_Panel.SetBool ("isShifted",true);
		};
	}

	public void openItems ()
	{
		if (minions_Panel.GetBool ("isShifted")){
			minions_Panel.SetBool ("isShifted",false);
			items_Panel.SetBool ("isShifted",true);
		}else if (menuButtons_Panel.GetBool ("isShifted") || items_Panel.GetBool ("isShifted")) {
		closeMenu ();

		} else {			
			menuButtons_Panel.SetBool ("isShifted", true);
			items_Panel.SetBool ("isShifted", true);
		}
	
	}

	public void openMenu ()
	{
		if (minions_Panel.GetBool ("isShifted") || items_Panel.GetBool ("isShifted")){
			minions_Panel.SetBool ("isShifted",false);
			items_Panel.SetBool ("isShifted",false);
			menu_Panel.SetBool ("isShifted",true);
		}else if (menuButtons_Panel.GetBool ("isShifted") || items_Panel.GetBool ("isShifted") || minions_Panel.GetBool ("isShifted")) {
		closeMenu ();

		} else {			
			menuButtons_Panel.SetBool ("isShifted", true);
			menu_Panel.SetBool ("isShifted", true);
		}
	
	}

	public void closeMenu(){
		menuButtons_Panel.SetBool ("isShifted",false);
		minions_Panel.SetBool ("isShifted",false);
		items_Panel.SetBool ("isShifted",false);
		menu_Panel.SetBool ("isShifted",false);
	}
		
}
