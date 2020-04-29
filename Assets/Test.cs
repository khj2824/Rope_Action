using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;

[System.Serializable]
public class Item_item
{
    public int count;
    public float time;
}

[System.Serializable]
public class database
{
    public List<Item_item> list = new List<Item_item>();
}


public class Test : MonoBehaviour
{
    public List<Item_item> ddd;
    public database data;

    void Start()
    {
        for(int i=0;i<6;i++)
        {
            ddd.Add(new Item_item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            load();
        }
    }

    void save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(database));
        FileStream stream
            = new FileStream(Application.dataPath + "/DATABASE/test.xml", FileMode.Create);

        serializer.Serialize(stream, data);
        stream.Close();
    }

    void load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(database));
        try
        {
            FileStream stream
                = new FileStream(Application.dataPath + "/DATABASE/test.xml", FileMode.Open);

            data = (database)serializer.Deserialize(stream);
        }
        catch(System.Exception e)
        {
            Debug.Log("load fail");
        }
    }
}
