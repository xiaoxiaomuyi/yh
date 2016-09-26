using UnityEngine;
using System.Collections;

public class GuaiWu : MonoBehaviour {
	public GameObject RenWu;
	private Animation anim;
	private CharacterController cc;
	private Vector3 move = Vector3.zero;
	private float GanJue = 10.0f;
	private float GonJi = 2.0f;
	private bool isRun = false;
	private bool isAttack = false;
	private int a = Random.Range(2,5);
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animation> ();
		cc = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		FaXian ();
	}

//	void Daiji(){
//		if (!isAttack) {
//			int a = Random.Range (0, 18);
//			this.transform.Rotate (new Vector3 (0, 10 * a, 0));
//			anim.CrossFade ("Run");
//			move = transform.TransformDirection (Vector3.forward);
//			move = move * 2.0f * Time.deltaTime;
//			move.y -= 9.8f * Time.deltaTime;
//			cc.Move (move);
//		}
//	}
	void FaXian(){
		if (Vector3.Distance (this.transform.position, RenWu.transform.position) < GanJue) {
			this.transform.LookAt (RenWu.transform);
			if (Vector3.Distance (this.transform.position, RenWu.transform.position) > GonJi) {
				anim.CrossFade ("Run");
				isRun = true;
				isAttack = false;
				move = transform.TransformDirection (Vector3.forward);
				move = move * 2.0f * Time.deltaTime;
				move.y -= 9.8f * Time.deltaTime;
				cc.Move (move);
			} else {
				anim.CrossFade ("Attack");
				isAttack = true;
				isRun = false;
			}
		}
	}
}
