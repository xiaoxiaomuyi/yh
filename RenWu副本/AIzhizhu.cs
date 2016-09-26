using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIzhizhu : MonoBehaviour {
	public Transform followTarget;
	public CharacterController con;
	public Animator ani;

	public float chouHen = 10f;
	public float attackDis = 1f;

	public float thinkTime = 1f;
	public float currentTime = 0f;

	public float walkTime = 5f;
	public float walkCurrentTime = 0f;


	public float walkThinkTime = 4f;
	public float walkThinkCurrentTime = 0f;

	int skillIndex = 1;
	int conut = 1;

	public static bool isAttack = false;

	public float Hp = 0f;
	public float MaxHp = 100f;
	public Slider slider;

	// Use this for initialization
	void Start () {
		InvokeRepeating("RangeSkillIndex",3,3);//重复调用,从第一次调用开始,每隔repeatRate时间调用一次.
		Hp = 100f;
	}
	void RangeSkillIndex()
	{
		skillIndex =Random.Range(1,4);
	}

	// Update is called once per frame
	void Update () {
		//思考 一段时间
		Think();

		//让Boss看向目标
		LookTarget();

		updateSliderValue ();

	}

	void  LookTarget()
	{

		if (Vector3.Distance (transform.position, followTarget.position) < chouHen) {
			transform.LookAt (followTarget);
			if (Vector3.Distance (transform.position, followTarget.position) > attackDis) {
				Vector3 moveDirection = transform.TransformDirection (Vector3.forward);
				moveDirection.y -= 9.8f;
				con.Move (moveDirection * 1f * Time.deltaTime);
				isAttack = false;
				ani.SetTrigger ("ToRun");
			}
			//抵达攻击区域，开始攻击
			else {
				ani.SetTrigger("ToA");
				isAttack = true;
			}
		} 
	}


	void Think()
	{
		if(isAttack)
			return;

		currentTime += Time.deltaTime;
		if(currentTime >= (thinkTime+walkTime+walkThinkTime))
		{
			currentTime = 0f;
		}
		else
		{
			walkCurrentTime+= Time.deltaTime;
			if(walkCurrentTime >= walkTime){
				ani.SetTrigger("ToIdle");
				walkThinkCurrentTime+=Time.deltaTime;
				if(walkThinkCurrentTime>= walkThinkTime)
				{
					walkThinkCurrentTime = 0f;
					walkCurrentTime =0f;
					float x = Random.Range(-1f,1f);
					float z= Random.Range(-1f,1f);
					transform.LookAt(transform.position + new Vector3(x,0,z));
				}
			}
			else
			{
				//漫游
				ani.SetTrigger ("ToRun");
				Vector3 moveDirection = transform.TransformDirection(Vector3.forward);
				moveDirection.y -= 9.8f;
				con.Move(moveDirection*1f*Time.deltaTime);
			}

		}
	}

	void OnTriggerEnter(Collider other)
	{
		XMLjiexi hz = XMLjiexi.Danli ();
		XMLjiexi1 dj = XMLjiexi1.Danli ();
		if (Hp > 0) {
			if(other.tag.Equals("huangziwuqi") && HuanZi.isAttack){
				Hp -= hz.HZList [0].gj / 2;
			}
	
			if (other.tag.Equals ("jn") && HuanZi.isAttack) {
				Hp -= hz.HZList [0].gj;
			}
		}
	
		if (Hp <= 0) {
			Destroy(this.gameObject);
			if (conut <= 1) {
				hz.XiuGai (1, "jy", hz.HZList [0].jingyan + 100f);
				//DengJixx._incan.jysld.value = hz.HZList [0].jingyan / dj.HZList [hz.HZList [0].dengji - 1].jingyan;
				if ((int)hz.HZList [0].jingyan >= (int)dj.HZList [hz.HZList [0].dengji - 1].jingyan) {
					DengJixx._incan.shenji (hz.HZList [0].dengji);
					HuanZi._incan.obja [3].SetActive (true);
					Invoke ("xiaoshi", 3);
				}
				conut++;
			}
		}
	}
	void xiaoshi(){
		HuanZi._incan.obja [3].SetActive (false);
	}
	
	void updateSliderValue(){
		slider.value = Hp / MaxHp;
	}
}
