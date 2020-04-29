using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Vector2 velocity = collision.transform.parent.GetComponent<Rigidbody2D>().velocity;
            collision.transform.parent.GetComponent<Rigidbody2D>().velocity =
                new Vector2(velocity.x * -0.4f, velocity.y * 0.4f);

        }
    }
}
