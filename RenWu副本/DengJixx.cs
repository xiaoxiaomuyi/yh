using UnityEngine;
using System.Collections;

public class DengJixx : MonoBehaviour {
	public static DengJixx _incan;
	public UISlider hpsld;
	public UISlider mpsld;
	public UISlider jysld;
	public UILabel djlb;
	private float Hp;
	private float Mp;
	private float Jy;
	private int Gj;
	private int Fy;
	private int Sd;
	// Use this for initialization
	void Start () {
		_incan = this;
		XMLjiexi danqianxx = XMLjiexi.Danli ();
		XMLjiexi1 dengjixx = XMLjiexi1.Danli ();
		djlb.text = danqianxx.HZList [0].dengji.ToString ();
		Hp = danqianxx.HZList [0].hp;
		Mp = danqianxx.HZList [0].mp;
		Jy = danqianxx.HZList [0].jingyan; 
		Gj = danqianxx.HZList [0].gj;
		Fy = danqianxx.HZList [0].fy;
		Sd = danqianxx.HZList [0].sd;
		for(int i = 0;i<dengjixx.HZList.Count;i++){
			if (danqianxx.HZList [0].dengji == i + 1) {
				jysld.value = Jy / dengjixx.HZList [i].jingyan;
				hpsld.value = Hp / dengjixx.HZList [i].hp;
				mpsld.value = Mp / dengjixx.HZList [i].mp;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		XMLjiexi hz = XMLjiexi.Danli ();
		XMLjiexi1 dj = XMLjiexi1.Danli ();
		djlb.text = hz.HZList [0].dengji.ToString ();
		jysld.value = hz.HZList [0].jingyan / dj.HZList [hz.HZList [0].dengji - 1].jingyan;
		hpsld.value = hz.HZList [0].hp / dj.HZList [hz.HZList [0].dengji - 1].hp;
		mpsld.value = hz.HZList [0].mp / dj.HZList [hz.HZList [0].dengji - 1].mp;
	}

//	public void genxin(){
//		XMLjiexi danqianxx = XMLjiexi.Danli ();
//		XMLjiexi1 dengjixx = XMLjiexi1.Danli ();
//		djlb.text = danqianxx.HZList [0].dengji.ToString ();
//		Hp = danqianxx.HZList [0].hp;
//		Mp = danqianxx.HZList [0].mp;
//		Jy = danqianxx.HZList [0].jingyan;
//		for(int i = 0;i<dengjixx.HZList.Count;i++){
//			if (danqianxx.HZList [0].dengji == i + 1) {
//				jysld.value = Jy / dengjixx.HZList [i].jingyan;
//				hpsld.value = Hp / dengjixx.HZList [i].hp;
//				mpsld.value = Mp / dengjixx.HZList [i].mp;
//			}
//		}
//	}

	public void shenji(int dj){
		XMLjiexi danqianxx = XMLjiexi.Danli ();
		XMLjiexi1 dengjixx = XMLjiexi1.Danli ();
		//danqianxx.HZList [0] = dengjixx.HZList [dj];
		danqianxx.XiuGai (1, "dj", dengjixx.HZList [dj].dengji);
		danqianxx.XiuGai (1, "hp", dengjixx.HZList [dj].hp);
		danqianxx.XiuGai (1, "mp", dengjixx.HZList [dj].mp);
		danqianxx.XiuGai (1, "jy", 0);
		danqianxx.XiuGai (1, "gj", dengjixx.HZList [dj].gj);
		danqianxx.XiuGai (1, "fy", dengjixx.HZList [dj].fy);
		danqianxx.XiuGai (1, "sd", dengjixx.HZList [dj].sd);
		//genxin ();
//		danqianxx.HZList [0].dengji++;
//		danqianxx.HZList [0] = dengjixx.HZList [dj];
//		danqianxx.HZList [0].jingyan = 0;
//		Hp = danqianxx.HZList [0].hp;
//		Mp = danqianxx.HZList [0].mp;
//		Jy = danqianxx.HZList [0].jingyan; 
//		for(int i = 0;i<dengjixx.HZList.Count;i++){
//			if (danqianxx.HZList [0].dengji == i + 1) {
//				jysld.value = Jy / dengjixx.HZList [i].jingyan;
//				hpsld.value = Hp / dengjixx.HZList [i].hp;
//				mpsld.value = Mp / dengjixx.HZList [i].mp;
//			}
//		}
	}
}
