using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Canvas			menuXP;
	[SerializeField]
	private Canvas			menuSkill;


	//RAYCAST
	private RaycastHit		_rayHit;
	private Ray				_ray;

	//MOUVEMENTS
	private NavMeshAgent	nav;
	private GameObject		target;

	private Animator		anim;

	//SLIDERS
	public Slider			HP_Ennemy;
	public Text				HPText;
	public Text				LvlText;
	public Text				Name;
	public GameObject		Panel_Ennemy;

	private Stat			stats;

	private float			t0;
	private float			t1;


	void Start () {
		t0 = Time.time;
		t1 = Time.time;
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
		target = null;
		stats = GetComponent<Stat> ();
	}

	void Update () {

		//RESTART
		if (this.GetComponent<Stat>().HP <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Time.time - t1 > 1f && GetComponent<Stat>().HP < GetComponent<Stat>().maxHealth()) {
			t1 = Time.time;
			GetComponent<Stat>().HP += 1;
		}
		//RAYCAST
		_ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.red);

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast(_ray, out _rayHit)) {
				Vector3		point = _rayHit.point;
				if (_rayHit.collider.gameObject.tag == "Ennemy") {
					target = _rayHit.collider.gameObject;
					nav.destination = target.transform.position;
				}
				else {
					nav.destination = point;
					target = null;
				}
			}
		}

		//TARGET'S DEATH
		if (target && target.GetComponent<Stat> ().HP <= 0) {
			anim.SetBool ("attacking", false);
			target = null;
		}
		//SLIDER
		if (target) {
			Stat 		script;

			script = target.GetComponent<Stat> ();

			float hp = (float)script.HP / (float)script.maxHealth () * 100;
			HP_Ennemy.GetComponent<Slider>().value = hp;
			HPText.GetComponent<Text> ().text = script.HP.ToString ();

			LvlText.GetComponent<Text>().text = "Lvl " + script.level;
			Name.GetComponent<Text>().text = script.name;
			nav.destination = target.transform.position;
			Panel_Ennemy.SetActive(true);
		}
		else {
			Panel_Ennemy.SetActive(false);
		}

		//MOUVEMENTS && ANIMATIONS
		if (target && Vector3.Distance(transform.position, target.transform.position) < 5f) {
			nav.destination = transform.position;
			Vector3 _direction = (target.transform.position - transform.position);
			transform.rotation = Quaternion.LookRotation(_direction);
			if (!anim.GetBool("attacking")) {
				anim.SetTrigger("attack");
				anim.SetBool ("attacking", true);
			}
			if (Time.time - t0 > 0.5f){
				stats.DealDamage(target);
				t0 = Time.time;
			}
		}
		if (transform.position != nav.destination) {
			anim.SetBool ("attacking", false);
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}

		//PLAYER'S DEATH
		if (GetComponent<Stat>().HP <= 0 && !anim.GetBool("dead")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}

		if (Input.GetKeyDown ("c")) {
			menuXP.gameObject.SetActive(!menuXP.gameObject.active);
		}
		if (Input.GetKeyDown ("n")) {
			menuSkill.gameObject.SetActive(!menuSkill.gameObject.active);
		}
		// if (anim.GetBool ("dead") || menuXP.gameObject.active) {
		// 	return;
		// }
	}

}
