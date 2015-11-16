using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSlider : MonoBehaviour {
	
	public Slider		HpSlider;
	public Slider		XpSlider;
	public Text			HPText;
	public Text			LvlText;
	private Stat 		script;

	void Start () {
		script = GetComponent<Stat> ();
	}

	void Update () {
		float hp = (float)script.HP / (float)script.maxHealth () * 100;
		HpSlider.GetComponent<Slider>().value = hp;
		HPText.GetComponent<Text> ().text = script.HP.ToString ();

		float xp = (float)script.XP / (float)script.expCap () * 100;
		XpSlider.GetComponent<Slider>().value = xp;

		LvlText.GetComponent<Text>().text = "Lvl " + script.level;
	}
}
