using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Player;
    public GameObject[] BG;

    GameObject ground;
    int county = 0;
    int count = 0;
    bool ismake;
    void Start()
    {
        ground = new GameObject("ground");
        ismake = false;
        for(int i=0;i<4;i++)
        {        
            GameObject aa = Instantiate(Ground, new Vector3(Random.Range(-0.7f, 6.2f), 1+i*4, 0), Quaternion.identity);
            aa.transform.SetParent(ground.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        county = (int)Player.transform.position.y;

        if(county>count)
        {
            for(int i=0;i<4;i++)
            {
                Instantiate(Ground,
                    new Vector3(Random.Range(-0.7f, 6.2f), county +16+ i * 4, 0),
                    Quaternion.identity).transform.SetParent(ground.transform);
            }
            count += 16;
        }
    }
}
