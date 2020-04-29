using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;


public class CharacterData : MonoBehaviour
{

    public static CharacterData instance = null;

    public List<string> _name;
    public List<int> _power;
    public List<int> _powerMax;
    public List<int> _luck;
    public List<int> _luckMax;
    public List<int> _shield;
    public List<int> _shieldMax;
    public List<string> _skill;
    public List<int> _upgrade;

    public string Coin_;
    public string Ruby_;

    float time;
    string loadtxt;

    void Awake()
    {
        time = 0;

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        TextAsset txtAsset;
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/test.xml", FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            loadtxt = sr.ReadToEnd();
            xmlDoc.LoadXml(loadtxt);
            stream.Close();
        }
        catch (System.Exception e)
        {
            txtAsset = (TextAsset)Resources.Load("XML/test");
            xmlDoc.LoadXml(txtAsset.text);
        }
        XmlNodeList all_nodes = xmlDoc.SelectNodes("Root/character");
        foreach(XmlNode node in all_nodes)
        {
            _name.Add(node.SelectSingleNode("name").InnerText);
            _power.Add(XmlConvert.ToInt32(node.SelectSingleNode("power").InnerText));
            _powerMax.Add(XmlConvert.ToInt32(node.SelectSingleNode("powerMax").InnerText));
            _luck.Add(XmlConvert.ToInt32(node.SelectSingleNode("luck").InnerText));
            _luckMax.Add(XmlConvert.ToInt32(node.SelectSingleNode("luckMax").InnerText));
            _shield.Add(XmlConvert.ToInt32(node.SelectSingleNode("shield").InnerText));
            _shieldMax.Add(XmlConvert.ToInt32(node.SelectSingleNode("shieldMax").InnerText));
            _skill.Add(node.SelectSingleNode("skill").InnerText);
            _upgrade.Add(XmlConvert.ToInt32(node.SelectSingleNode("upgrade").InnerText));
        }
        Coin_ = xmlDoc.SelectSingleNode("Root/coin").InnerText;
        Ruby_ = xmlDoc.SelectSingleNode("Root/ruby").InnerText;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if((int)(time%10)==9)
        {
            saveXML();
            time = 0;
        }
    }

    void saveXML()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        //루트 노드 생성
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "Root", string.Empty);
        xmlDoc.AppendChild(root);

        XmlNode character;
        for (int i = 0; i < 6; i++)
        {
            //자식 노드 생성
            character = xmlDoc.CreateNode(XmlNodeType.Element, "character", string.Empty);
            root.AppendChild(character);

            XmlElement name = xmlDoc.CreateElement("name");
            name.InnerText = _name[i];
            character.AppendChild(name);

            XmlElement power = xmlDoc.CreateElement("power");
            power.InnerText = _power[i].ToString();
            character.AppendChild(power);

            XmlElement powerMAX = xmlDoc.CreateElement("powerMax");
            powerMAX.InnerText = _powerMax[i].ToString();
            character.AppendChild(powerMAX);

            XmlElement luck = xmlDoc.CreateElement("luck");
            luck.InnerText = _luck[i].ToString();
            character.AppendChild(luck);

            XmlElement luckMAX = xmlDoc.CreateElement("luckMax");
            luckMAX.InnerText = _luckMax[i].ToString();
            character.AppendChild(luckMAX);

            XmlElement shield = xmlDoc.CreateElement("shield");
            shield.InnerText = _shield[i].ToString();
            character.AppendChild(shield);

            XmlElement shieldMAX = xmlDoc.CreateElement("shieldMax");
            shieldMAX.InnerText = _shieldMax[i].ToString();
            character.AppendChild(shieldMAX);

            XmlElement skill = xmlDoc.CreateElement("skill");
            skill.InnerText = _skill[i].ToString();
            character.AppendChild(skill);

            XmlElement upgrade = xmlDoc.CreateElement("upgrade");
            upgrade.InnerText = _upgrade[i].ToString();
            character.AppendChild(upgrade);
        }

        XmlElement Coin = xmlDoc.CreateElement("coin");
        Coin.InnerText = Coin_;
        root.AppendChild(Coin);

        XmlElement Ruby = xmlDoc.CreateElement("ruby");
        Ruby.InnerText = Ruby_;
        root.AppendChild(Ruby);

        
        xmlDoc.Save(Application.persistentDataPath + "/test.xml");
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            saveXML();
        }
    }
}
