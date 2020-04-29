using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rope : MonoBehaviour
{

    BoxCollider2D ropecol;
    GameObject col;
    public Vector3 startpos;
    public Vector3 normalpos;
    public Vector3 deltapos;
    public Vector3 endpos;
    LineRenderer ropeLine;
    Vector3 playerpos;
    float time;
    bool isend = true;
    bool linemove;

    public bool iscol;


    // Start is called before the first frame update
    void Start()
    {
        linemove = false;
        iscol = false;
        time = 0;
        ropeLine = GetComponent<LineRenderer>();
        ropeLine.material = Resources.Load("Material/Rope")as Material;
        ropeLine.startWidth = 0.1f;
        ropeLine.endWidth = 0.1f;
        ropeLine.useWorldSpace = false;

        startpos = Vector3.zero;
        normalpos = transform.parent.GetChild(0).GetComponent<CharacterMove>().targetpos;
        normalpos = normalpos / (Vector2.Distance(normalpos,Vector2.zero));

        col = new GameObject("Collider");
        col.transform.position = transform.position;
        col.transform.SetParent(transform);
        col.AddComponent<BoxCollider2D>();
        ropecol = col.GetComponent<BoxCollider2D>();
        ropecol.isTrigger = true;

        playerpos = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isend)
        {
            creatLine();
            playerpos = transform.position;
        }
        else
        {
            iscol = false;
        }

        if(linemove)
        {
            Vector3 movepos = (playerpos - transform.position) + endpos;
            ropeLine.SetPosition(1, movepos);
            transform.parent.GetChild(0).GetComponent<CharacterMove>().ismove = true;
        }
    }

    void creatLine()
    {
        Vector3 movepos = new Vector3(normalpos.x * transform.parent.GetChild(0).GetComponent<CharacterMove>().direct, normalpos.y);
        if (iscol == false)
        {
            time += Time.deltaTime;
            if (time > 0.1f && time < 0.12f) col.AddComponent<Collider>();
            ropeLine.SetPosition(0, startpos);
            endpos = startpos + movepos * time * 40f;
            ropeLine.SetPosition(1, endpos);
            deltapos = endpos;
            creatCol();
        }
        else
        {
            linemove = true;
            isend = false;
        }
    }

    void creatCol()
    {
        float lineLength = Vector3.Distance(startpos, endpos);
        ropecol.size = new Vector2(lineLength, 0.1f);
        Vector3 midpos = (startpos + endpos) / 2+transform.position;
        ropecol.transform.position = midpos;
        float angle = Mathf.Atan((endpos.y - startpos.y) / (endpos.x - startpos.x));
        col.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * Mathf.Rad2Deg));
    }
}
