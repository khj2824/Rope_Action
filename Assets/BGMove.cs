using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public GameObject[] BGobj;
    public GameObject player;
    int count = 0;
    float playery;
    // Update is called once per frame
    private void Start()
    {
        count = (int)player.transform.position.y;
    }
    void Update()
    {
        transform.position = 0.5f*((Vector2)Camera.main.transform.position + new Vector2(-5f, 0));
        playery = player.transform.position.y;
        if (playery > (count + 50))
        {
            BGobj[((count + 50) / 50) % 2].transform.position += new Vector3(0, 50f);
            count += 50;
        }
        if(playery<(count-1))
        {
            BGobj[(count) / 50 % 2].transform.position += new Vector3(0, -50f);
            count -= 50;
        }
    }
}
