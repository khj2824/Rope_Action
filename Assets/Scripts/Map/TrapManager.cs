using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gear;
    public GameObject Fireball;

    int Playery = 0;
    int gearcount = 1;
    float geary = 0;

    int Fireballcount = 1;
    float Firebally = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Playery = (int)Player.transform.position.y;
        if(Playery>geary)
        {
            GearInit(gearcount);
            gearcount++;
        }
        if(Playery>Firebally)
        {
            Fireballinit(Fireballcount);
            Fireballcount++;
        }
    }

    void GearInit(int X)
    {
        GameObject aa = Instantiate(Gear,
            new Vector3(Random.Range(0, 2) * 9.9f - 2.1f, geary + 40 / Mathf.Pow(X, 1 / 2f) + 8),
            Quaternion.identity);
        geary += 40 / Mathf.Pow(X, 1 / 2f) + 8;
    }

    void Fireballinit(int X)
    {
        GameObject aa = Instantiate(Fireball,
            new Vector3(Random.Range(-1f, 6f), Firebally + 40 / Mathf.Pow(X, 1 / 3f) + 5),
            Quaternion.identity);
        Firebally += 40 / Mathf.Pow(X, 1 / 3f) + 5;
    }
}
