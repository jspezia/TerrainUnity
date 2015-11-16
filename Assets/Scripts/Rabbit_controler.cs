using UnityEngine;
using System.Collections;

public class Rabbit_controler : MonoBehaviour {

	private RaycastHit		_rayHit;
	private Ray				_ray;
	private NavMeshAgent	nav;

	private Animator		anim;

	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
	}

	void Update () {
		//RAYCAST
		_ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(_ray.origin, _ray.direction * 10f, Color.red);

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast(_ray, out _rayHit)) {
				Vector3		point = _rayHit.point;
				nav.destination = point;
			}
		}
	}
}