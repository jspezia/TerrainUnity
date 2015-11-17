using UnityEngine;
using System.Collections;

public class Sardine : MonoBehaviour {

	public GameObject	start;
	public GameObject	end;
	public float		speed = 0.5f;

	private	Vector3 	_direction;
	private	float		_t0;

	void Start () {
		transform.position = start.transform.position;
		_direction = (end.transform.position - start.transform.position);
		_t0 = Time.time;
		Vector3 rotation = end.transform.position;
		transform.localEulerAngles = rotation;
	}
	
	void Update () {
		if (transform.position.y > 50f)
			transform.Translate(_direction * Time.deltaTime * speed, Space.World);
		if (Time.time - _t0 > 5f) {
			transform.position = start.transform.position;
			_t0 = Time.time;
		}
	}
}
