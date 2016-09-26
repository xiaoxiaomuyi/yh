using UnityEngine;
using System.Collections;

public class CD : MonoBehaviour {
	public UISprite sp;
	public UILabel label;
	public float cd;
	private float currentTime;
	private float hasTime;
	private bool isCan = true;
	// Use this for initialization
	void Start () {
		currentTime = 0;
		cd = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (sp.fillAmount.Equals (1)) {
			return;
		}
		currentTime += Time.deltaTime;
		if (currentTime <= 4) {
			hasTime = cd - Mathf.FloorToInt (currentTime);
			label.text = (hasTime-1).ToString ();
		} else {
			hasTime = cd - currentTime;
			hasTime = hasTime * 10;
			hasTime = (int)hasTime;
			hasTime = hasTime / 10;
			label.text = hasTime.ToString ();
		}
		sp.fillAmount = currentTime / cd;
		if (currentTime >= cd) {
			currentTime = 0;
			isCan = true;
			label.enabled = false;
			this.GetComponent<UIButton> ().enabled = true;
		}
	}
	void OnClick(){
		if (isCan) {
			sp.fillAmount = 0;
			label.enabled = true;
			isCan = false;
			this.GetComponent<UIButton> ().enabled = false;
		}
	}
}
