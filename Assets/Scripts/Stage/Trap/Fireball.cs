using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float direction;
    void Start()
    {
        direction = Random.Range(-2f, 2f);
    }
    
    void Update()
    {
        transform.position += new Vector3(direction*Time.deltaTime,-2f*Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 velocity = -collision.transform.parent.GetComponent<Rigidbody2D>().velocity;
            float angle = Vector2.Angle(velocity, collision.transform.parent.position - transform.position);
            angle = angle * Mathf.Deg2Rad;
            collision.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(velocity.x * Mathf.Cos(angle) - velocity.y * Mathf.Sin(angle),
                velocity.x * Mathf.Sin(angle) + velocity.y * Mathf.Cos(angle))*0.4f;
            collision.transform.GetComponent<CharacterMove>().isdie = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetChild(0).GetComponent<CharacterMove>().isdie = true;
        }
    }
}
