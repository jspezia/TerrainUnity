using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject		Entity;
	public float			timeRespawn;
	public Transform		localisation;

	private GameObject		_creature;
	private float			t0;

	void Start () {
		t0 = Time.time;
		_creature = (GameObject)Instantiate(Entity, localisation.position, Quaternion.identity);
	}
	
	void Update () {
		if (GetComponent<Stat>().HP <= 0)
			Destroy(gameObject);
		if (Time.time - t0 > timeRespawn && !_creature) {
			_creature = (GameObject)Instantiate(Entity, localisation.position, Quaternion.identity);
			t0 = Time.time;
		}
	}
}
