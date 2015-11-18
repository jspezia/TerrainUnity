using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragSkill : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	//public GameObject manager;
	//public GameObject spawnTower;
	Vector3 startPosition;
	RaycastHit hit;

	void Start () {
		itemBeingDragged = null;
	}

	public void OnBeginDrag (PointerEventData enventData) {
		//if (playerInfo.playerEnergy - spawnTower.GetComponent<towerScript>().energy >= 0) {
			itemBeingDragged = gameObject;
			startPosition = transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		//}
	}

	public void OnDrag (PointerEventData enventData) {
		if (itemBeingDragged) {
			transform.position = Input.mousePosition;
		}
	}

	public void OnEndDrag (PointerEventData enventData) {
		if (itemBeingDragged) {
			itemBeingDragged = null;
			if (transform.position != startPosition) {
				if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
					if (hit.collider.gameObject.tag == "Skill") {
						Debug.Log ("Skill ");
					}
				}
				transform.position = startPosition;
				GetComponent<CanvasGroup> ().blocksRaycasts = true;
			}
		}
	}
}
