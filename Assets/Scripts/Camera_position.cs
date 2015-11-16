using UnityEngine;
using System.Collections;

public class Camera_position : MonoBehaviour {

	public GameObject		Player;

	private Vector3		_position;
	
	void Update () {
		_position = Player.transform.position;
		transform.position = new Vector3(_position.x, _position.y + 45f, _position.z - 37f);
	}
}
