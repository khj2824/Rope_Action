using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundisCol : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.name == "Player" &&
    //        collision.transform.parent.GetComponent<Rigidbody2D>().velocity.y < 0)
    //    {
    //        GetComponent<BoxCollider2D>().isTrigger = false;
    //        collision.GetComponent<CharacterMove>().isbool = true;
    //        if(collision.transform.parent.childCount>=2&&collision.transform.GetChild(1)!=null)
    //        {
    //            Destroy(collision.transform.parent.GetChild(1).gameObject);
    //        }
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    GetComponent<BoxCollider2D>().isTrigger = true;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Oncollision");
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.transform.GetChild(0).GetComponent<CharacterMove>().isbool = true;
    //        if (collision.transform.childCount == 2 && collision.transform.GetChild(1) != null)
    //        {
    //            Destroy(collision.transform.GetChild(1).gameObject);
    //        }
    //    }
    //}
}
