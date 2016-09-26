using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//杨浩
//
public class HuanZi : MonoBehaviour {
	public static HuanZi _incan;
	public EasyJoystick joy;
	public GameObject[] obja;   //te xiao
	public GameObject shibai;
	public Animator anim;
	private Vector3 vec;
	private CharacterController cc;
	private Vector3 move = Vector3.zero;
	private bool isRun = false;
	private bool isIdle;
	public static bool isDie = false;
	public static bool isAttack = false;
	private AnimatorStateInfo _info;
	private int Acount = 0;
	private XMLjiexi hz;
	void Start () {
		shibai.SetActive (false);
		_incan = this;
		hz = XMLjiexi.Danli ();
		anim = this.GetComponent<Animator> ();
		cc = this.GetComponent<CharacterController> ();
		_info=anim.GetCurrentAnimatorStateInfo(0);
		for (int i = 0; i < obja.Length; i++) {
			obja [i].SetActive (false);
		}
		InvokeRepeating ("huixue", 5f, 1f);
	}
	void Update () {
//		if (Input.GetMouseButton (1)) {
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			RaycastHit hit;
//			if (Physics.Raycast (ray, out hit)) {
//				vec = hit.point;
//			}
//		}
//		if (Vector3.Distance (vec, this.transform.position) > 1F && !isAttack && !isDie) {
//			anim.SetTrigger ("ToRun");
//			isRun = true;
//			Vector3 step = Vector3.ClampMagnitude (vec - this.transform.position, 0.1f);
//			this.transform.LookAt (vec);
//			cc.Move (step);
//		}
//		else {
//			if (isRun && !isAttack && !isDie) {
//				anim.SetTrigger ("ToIdle");
//			}
//			isRun = false;
//		}
//		//updatePercent ();
		float x = joy.JoystickTouch.x;
		float z = joy.JoystickTouch.y;
		if (joy.JoystickTouch != Vector2.zero && !isAttack && !isDie) {
			if (!isRun) {
				anim.SetTrigger ("ToRun");
				isRun = true;
			}
			if (isRun) {
				this.transform.LookAt (new Vector3 (this.transform.position.x + x, this.transform.position.y, this.transform.position.z + z));
				move = transform.TransformDirection (Vector3.forward);
				move = move * hz.HZList[0].sd * Time.deltaTime;
				move.y -= 9.8f * Time.deltaTime;
				cc.Move (move);
			}
		} else {
			if (isRun && !isAttack && !isDie) {
				anim.SetTrigger ("ToIdle");
			}
			isRun = false;
		}
	}
	public void button(GameObject obj){
		if (!isDie) {
			switch (obj.name) {
			case "A":
//			if (_info.IsName ("Idle") && Acount == 0) {
//				anim.SetTrigger ("ToA1");
//				Acount++;
//			} else if (_info.IsName ("A1") || _info.IsName ("Idle") && Acount == 1) {
//				anim.SetTrigger ("ToA2");
//				Acount++;
//			} else if (_info.IsName ("A2") || _info.IsName ("Idle") && Acount == 2) {
//				anim.SetTrigger ("ToA3");
//				Acount = 0;
//			}
//			if (_info.IsName ("Idle")) {
//				Invoke ("zhi0", 2);
//			}
				anim.SetTrigger ("ToA1");
				isAttack = true;
				isRun = false;
				Invoke ("xiaoshia", 1f);
				break;
			case "JN1":
				obja [0].SetActive (true);
				anim.SetTrigger ("ToJiNeng1");
				hz.XiuGai (1, "mp", hz.HZList [0].mp - 5f);
				Invoke ("xiaoshi0", 2.2f);
				isAttack = true;
				isRun = false;
				break;
			case "JN2":
				obja [1].SetActive (true);
				anim.SetTrigger ("ToJiNeng2");
				hz.XiuGai (1, "mp", hz.HZList [0].mp - 7f);
				Invoke ("xiaoshi1", 2.5f);
				isAttack = true;
				isRun = false;
				break;
			case "JN3":
				obja [2].SetActive (true);
				anim.SetTrigger ("ToJiNeng3");
				hz.XiuGai (1, "mp", hz.HZList [0].mp - 10f);
				Invoke ("xiaoshi2", 5f);
				isAttack = true;
				isRun = false;
				break;
			default:
				break;
			}
		}
	}
//	void zhi0(){
//		Acount = 0;
//	}
	void xiaoshi0(){
		obja [0].SetActive (false);
		isAttack = false;
	}
	void xiaoshi1(){
		obja [1].SetActive (false);
		isAttack = false;
	}
	void xiaoshi2(){
		obja [2].SetActive (false);
		isAttack = false;
	}
	void xiaoshia(){
		isAttack = false;
	}
	void OnTriggerEnter(Collider other)
	{
		XMLjiexi1 dj = XMLjiexi1.Danli ();
		float shanhai = 5f - hz.HZList [0].fy;
		if (hz.HZList[0].hp > 0) {
			if (other.tag.Equals ("guaiwuwuqi") && (AIzhaoxin.isAttack||AIxiniu.isAttack||AIzhizhu.isAttack)) {
				if (shanhai > 0) {
					hz.XiuGai (1, "hp", hz.HZList [0].hp - shanhai);
				}
			}
		}

		if (hz.HZList[0].hp <= 0) {
			anim.SetBool ("ToSi", true);
			isDie = true;
			shibai.SetActive (true);
			Destroy(this.gameObject);
		}
	}

//	void updatePercent(){
//		slider.value = Hp / maxHp;
//	}
	void huixue(){
		if (hz.HZList[0].hp <= 70) {
			hz.XiuGai (1, "hp", hz.HZList [0].hp + 10f);
		}
		if (hz.HZList [0].mp <= 50) {
			hz.XiuGai (1, "mp", hz.HZList [0].mp + 5f);
		}
	}
}
