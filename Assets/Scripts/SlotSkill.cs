using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotSkill : MonoBehaviour, IDropHandler {

	public void OnDrop (PointerEventData eventData) {
		GetComponent<Image>().color = DragSkill.itemBeingDragged.GetComponent<Image>().color;
	}
}
