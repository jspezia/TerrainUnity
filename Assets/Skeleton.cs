using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour {

	private Animator	anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("r")) {
			anim.SetBool ("attack", false);
			anim.SetBool ("running", true);
		} else {
			anim.SetBool("running", false);
		}
		if (Input.GetKey ("d")) {
			anim.SetBool ("dead", true);
		} else {
			anim.SetBool ("dead", false);
		}
		if (Input.GetKey ("a")) {
			anim.SetBool ("running", false);
			anim.SetBool ("attack", true);
		} else {
			anim.SetBool ("attack", false);
		}
		if (Input.GetKey ("q")) {
			anim.SetBool ("resurect", true);
		} else {
			anim.SetBool ("resurect", false);
		}
	}
}
