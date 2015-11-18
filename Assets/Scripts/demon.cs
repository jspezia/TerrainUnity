using UnityEngine;
using System.Collections;

public class demon : MonoBehaviour {

	private Animation 		anim;
	private GameObject		target = null;
	private NavMeshAgent	nav;
	private float			t0;
	private Stat			stats;
	private bool 			is_running;
	private bool 			is_attacking;
	private bool 			is_dead;
	private bool 			is_idling;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animation>();
		// nav.speed = 12;
		stats = GetComponent<Stat> ();
		nav.destination = transform.position;
		set_bool(false, false, false, true);
	}
	
	// Update is called once per frame
	void Update () {
		// DELETE demon after death
		if (is_dead) {
			if (Time.time - t0 > 1.5f) {
				Destroy(gameObject);
				Time.timeScale = 0f;
			}
			return;
		}

		// LOOP Animations
		if (!anim.isPlaying && !is_dead)
		{
			if (is_idling)
				anim.GetComponent<Animation>().Play("idle");
			else if (is_running)
				anim.GetComponent<Animation>().Play("run");
			else if (is_attacking)
				anim.GetComponent<Animation>().Play("attack 2");
		}

		//ATTACK player
		if (target) {
			nav.destination = target.transform.position;
			Vector3 _direction = (target.transform.position - transform.position);
			transform.rotation = Quaternion.LookRotation(_direction);
			if (Vector3.Distance(transform.position, target.transform.position) < 5f) {
				nav.destination = transform.position;
				if (!is_attacking && !is_dead){
					anim.GetComponent<Animation>().Play("attack 2");
					set_bool(false, true, false, false);
				}
				if (Time.time - t0 > 1f){
					stats.DealDamage(target);
					t0 = Time.time;
				}
			}
			else {
				if (!is_running && !is_idling) {
					anim.GetComponent<Animation>().Play("idle");
					set_bool(false, false, false, true);
				}
			}
		}

		if (Vector3.Distance(transform.position, nav.destination) > 5f){
			if (!is_running) {
				anim.GetComponent<Animation>().Play("run");
				set_bool(true, false, false, false);
			}
		}
		else
		{
			if (!is_attacking && !is_idling && !is_dead) {
				anim.GetComponent<Animation>().Play("idle");
				set_bool(false, false, false, true);
			}
		}
		if (GetComponent<Stat>().HP <= 0) {
			t0 = Time.time;
			if (!is_dead) {
				anim.GetComponent<Animation>().Play("death");
				set_bool(false, false, true, false);
			}
			
		}
	}

	void set_bool(bool running, bool attacking, bool dead, bool idling)
	{
		is_running = running;
		is_attacking = attacking;
		is_dead = dead;
		is_idling = idling;
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			target = coll.gameObject;
		}
	}
}
