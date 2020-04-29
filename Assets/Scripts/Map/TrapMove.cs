using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    public ParticleSystem dieparticle;
    public GameObject player;
    int speed = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = 1 + (int)player.transform.position.y / 200;
        transform.position += Time.deltaTime * speed * Vector3.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.GetChild(0).GetComponent<CharacterMove>().shield -= 100;
            player.transform.GetChild(0).GetComponent<CharacterMove>().isdie = true;
        }
    }
}
