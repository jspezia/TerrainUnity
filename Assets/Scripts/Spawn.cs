using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject		zombie;

	private GameObject		_zombie;
	private float			size;
	private float			t0;

	void Start () {
		_zombie = null;
		t0 = Time.time;
	}

	void Update () {
		if (!_zombie) {
			Vector3 zombie_pos = new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z);
			_zombie = (GameObject)Instantiate(zombie, zombie_pos, Quaternion.identity);
			_zombie.GetComponent<Transform>().localScale -= new Vector3(0.99f, 0.99f, 0.99f);
		}
		if (Time.time - t0 > 0.002 && _zombie.GetComponent<Transform>().localScale.x < 1f) {
			_zombie.GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0.01f);
			t0 = Time.time;
		}
	}
}
