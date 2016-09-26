using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class XMLjiexi1 : MonoBehaviour{
	private static XMLjiexi1 myXMLParse;
	public string xmlFileName = "/RenWuXInXi.xml";
	private string xmlFilePath = string.Empty;
	public List<Demo1> HZList = new List<Demo1> ();
	private XMLjiexi1(){
		JieXi ();
	}
	public static XMLjiexi1 Danli(){
		if (myXMLParse == null) {
			myXMLParse = new XMLjiexi1 ();
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
}
