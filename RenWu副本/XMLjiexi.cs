using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class XMLjiexi : MonoBehaviour {
	private static XMLjiexi myXMLParse;
	public string xmlFileName = "/DanQianXinXi.xml";
	private string xmlFilePath = string.Empty;
	public List<Demo1> HZList = new List<Demo1> ();
	private XMLjiexi(){
		JieXi ();
	}
	public static XMLjiexi Danli(){
		if (myXMLParse == null) {
			myXMLParse = new XMLjiexi ();
		}
		return myXMLParse;
	}
	public void JieXi(){
		xmlFilePath = Application.streamingAssetsPath + xmlFileName;
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);

		XmlNode root = doc.SelectSingleNode ("DengJi");
		foreach (XmlElement child in root) {
			Demo1 hz = new Demo1 ();
			foreach (XmlElement item in child) {
				if (item.Name == "dj") {
					hz.dengji = int.Parse (item.InnerText);
				} else if (item.Name == "hp") {
					hz.hp = float.Parse (item.InnerText);
				} else if (item.Name == "mp") {
					hz.mp = float.Parse (item.InnerText);
				} else if (item.Name == "jy") {
					hz.jingyan = float.Parse (item.InnerText);
				} else if(item.Name == "gj"){
					hz.gj = int.Parse (item.InnerText);
				}else if(item.Name == "fy"){
					hz.fy = int.Parse (item.InnerText);
				}else if(item.Name == "sd"){
					hz.sd = int.Parse (item.InnerText);
				}
			}
			HZList.Add (hz);
		}
	}

	public void XiuGai(int index,string name,float value){
		xmlFilePath = Application.streamingAssetsPath + xmlFileName;
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);

		XmlNode root = doc.SelectSingleNode ("DengJi");
		XmlNode xmln = root.FirstChild;
		for (int i = 0; i < index-1; i++) {
			xmln = xmln.NextSibling;
		}
		foreach (XmlElement child in xmln) {
			if (child.Name == name) {
				child.InnerText = value.ToString();
			}
		}
		doc.Save (xmlFilePath);
		if (name == "dj") {
			HZList [index-1].dengji = (int)value;
		}  else if (name == "hp") {
			HZList [index-1].hp = value;
		}  else if (name == "mp") {
			HZList [index-1].mp = value;
		}  else if(name == "jy"){
			HZList [index-1].jingyan = value;
		}else if(name == "gj"){
			HZList [index-1].gj = (int)value;
		}else if(name == "fy"){
			HZList [index-1].fy = (int)value;
		}else if(name == "sd"){
			HZList [index-1].sd = (int)value;
		}
	}

	public void HuanYuan(){
		xmlFilePath = Application.streamingAssetsPath + xmlFileName;
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);

		XmlDocument doc1 = new XmlDocument ();
		doc1.Load (Application.streamingAssetsPath + "/Levels1.xml");

		doc = doc1;
		doc.Save (xmlFilePath);

		XmlNode root = doc.SelectSingleNode ("Levels");
		foreach (XmlElement child in root) {
			Demo1 hz = new Demo1 ();
			foreach (XmlElement item in child) {
				if (item.Name == "dj") {
					hz.dengji = int.Parse (item.InnerText);
				} else if (item.Name == "hp") {
					hz.hp = float.Parse (item.InnerText);
				} else if (item.Name == "mp") {
					hz.mp = float.Parse (item.InnerText);
				} else if (item.Name == "jy") {
					hz.jingyan = float.Parse (item.InnerText);
				} else if(item.Name == "gj"){
					hz.gj = int.Parse (item.InnerText);
				}else if(item.Name == "fy"){
					hz.fy = int.Parse (item.InnerText);
				}else if(item.Name == "sd"){
					hz.sd = int.Parse (item.InnerText);
				}
			}
			HZList.Add (hz);
		}
	}
	public void baocun(){
		xmlFilePath = Application.streamingAssetsPath + xmlFileName;
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		doc.Save (xmlFilePath);
	}
}
