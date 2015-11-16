using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuStatHandler : MonoBehaviour {

	[SerializeField]
	private	Canvas			menu;
	[SerializeField]
	private	GameObject		player;
	private Stat			playerStats;
	[SerializeField]
	private Text			lvl;
	[SerializeField]
	private Text			str;
	[SerializeField]
	private Text			agi;
	[SerializeField]
	private Text			con;
	[SerializeField]
	private Text			arm;
	[SerializeField]
	private Text			pts;
	[SerializeField]
	private List<Button>	ups;

	[SerializeField]
	private Text			dam;
	[SerializeField]
	private Text			hp;
	[SerializeField]
	private Text			xp;
	[SerializeField]
	private Text			nextXP;
	[SerializeField]
	private Text			cre;

	void Start () {
		playerStats = player.GetComponent<Stat> ();
		str.text = "Stren. " + playerStats.STR.ToString ();
		agi.text = "Agility " + playerStats.AGI.ToString ();
		con.text = "Constit. " + playerStats.CON.ToString ();
		arm.text = "Armor " + playerStats.Armor.ToString ();
		pts.text = "UP Pts " + playerStats.characs.ToString ();
	}

	void Update () {
		string	min = playerStats.minDamage ().ToString();
		string	max = playerStats.maxDamage ().ToString();
		string level = playerStats.level.ToString ();

		lvl.text = "Maya[Lv." + level + "]";
		dam.text = "Dam. " + min + "-" + max;
		hp.text = "Health " + playerStats.HP.ToString ();
		xp.text = "XP " + playerStats.XP.ToString ().ToString ();
		nextXP.text = "N. XP " + playerStats.expCap ().ToString ();
		cre.text = "Credits " + playerStats.money.ToString ();
	}

	void checkRemainingPoints () {
		playerStats.characs--;
		pts.text = "UP Pts " + playerStats.characs.ToString ();
		if (playerStats.characs <= 0) {
			foreach (Button u in ups) {
				u.gameObject.SetActive(false);
			}
		}
	}

	public void exitMenu() {
		Debug.Log ("Close");
		menu.gameObject.SetActive (false);
	}

	public void unpgradeStrength () {
		playerStats.STR++;
		str.text = "Stren. " + playerStats.STR.ToString ();
		checkRemainingPoints ();
	}

	public void unpgradeAgility () {
		playerStats.AGI++;
		agi.text = "Agility " + playerStats.AGI.ToString ();
		checkRemainingPoints ();
	}

	public void unpgradeConstitution () {
		playerStats.CON++;
		con.text = "Constit. " + playerStats.CON.ToString ();
		checkRemainingPoints ();
	}

}
