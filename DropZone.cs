using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null) {
			return;
		}
		Debug.Log ("onPointerEnter");
		Draggable d = eventData.pointerDrag.GetComponent <Draggable>();
		if (d!=null) 
		{
			d.placeHolderParent = this.transform;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null) {
			return;
		}
		Debug.Log ("onPointerExit");
		Draggable d = eventData.pointerDrag.GetComponent <Draggable>();
		if (d!=null && d.placeHolderParent == this.transform) 
		{
			d.placeHolderParent = d.parentToReturnTo;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log ( eventData.pointerDrag.name + "OnDrop to " + gameObject.name);
		Draggable d = eventData.pointerDrag.GetComponent <Draggable>();
		if (d!=null) 
		{
			d.parentToReturnTo = this.transform;
		}
	}

}
