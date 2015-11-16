using UnityEngine;
using System.Collections;

public class CheckAnimations : MonoBehaviour {

	private Animator	anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("r")) {
			anim.SetBool ("running", true);
		} else {
			anim.SetBool("running", false);
		}
		if (Input.GetKeyDown ("a")) {
			anim.SetTrigger ("attack");
			anim.SetBool ("attacking", true);
		} else if (Input.GetKeyDown ("s")) {
			anim.SetBool ("attacking", false);
		}
		if (Input.GetKeyDown ("d")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}
	}
}
