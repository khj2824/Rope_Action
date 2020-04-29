using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public Vector3 colpos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Ground")
        {
            transform.parent.parent.GetChild(0).GetComponent<CharacterMove>().iscol = true;
            transform.parent.parent.GetChild(0).GetComponent<CharacterMove>().isforce = true;
            transform.parent.GetComponent<Rope>().iscol = true;
            Destroy(gameObject);
        }
    }
}
