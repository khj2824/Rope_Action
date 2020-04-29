using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLManager : MonoBehaviour
{
    // Resources/XML/TestItem.XML 파일.
    string xmlFileName = "test";

    void Start()
    {
        //파일 불러오기 //

        //TextAsset txtXML = (TextAsset)Resources.Load("XML/test");
        //XmlDocument xml = new XmlDocument();
        //xml.LoadXml(txtXML.text);

        //XmlNodeList id_Table = xml.GetElementsByTagName("name");
        //int aaa = int.Parse(id_Table[0].InnerText);
        //Debug.Log(aaa);

        //XmlNodeList nodes = xml.SelectNodes("Root/text");
        //string s = "";
        //foreach(XmlNode node in nodes)
        //{
        //    Debug.Log("name : " + node.SelectSingleNode("name").InnerText);
        //    Debug.Log("Phone : " + node.SelectSingleNode("phone").InnerText);
        //    Debug.Log("address : " + node.SelectSingleNode("address").InnerText);
        //}

        //파일 만들기 //

        //XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        //XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
        //xmlDoc.AppendChild(root);

        //XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
        //root.AppendChild(child);

        //XmlElement name = xmlDoc.CreateElement("Name");
        //name.InnerText = "wergia";
        //child.AppendChild(name);

        //XmlElement lv = xmlDoc.CreateElement("Level");
        //lv.InnerText = "1";
        //child.AppendChild(lv);

        //XmlElement exp = xmlDoc.CreateElement("Experience");
        //exp.InnerText = "45";
        //child.AppendChild(exp);

        //xmlDoc.Save("./Assets/Resources/Character.xml");

        //파일 덮어씌워 저장하기

        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        
        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = nodes[0];
        Debug.Log(nodes[0].Name);

        character.SelectSingleNode("Name").InnerText = "wergia";
        character.SelectSingleNode("Level").InnerText = "5";
        character.SelectSingleNode("Experience").InnerText = "180";

        xmlDoc.Save("./Assets/Resources/Character.xml");
    }
}
