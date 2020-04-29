using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public int direct;
    float time;
    GameObject rope;

    public Vector2 targetpos;
    public GameObject player;
    public GameObject ResultPanel;
    public ParticleSystem dieparticle;
    public bool isbool;
    public bool ismove;
    public bool isropemake;
    public bool isforce;
    public bool iscol;
    public bool jointmake;
    public bool isdie;

    float power;
    int luck;
    public int shield;
    bool notclick;

    void Start()
    {
        time = 0;
        notclick = false;
        direct = 1;
        isdie = false;
        iscol = true;
        ismove = false;
        jointmake = false;
        isbool = true;
        isforce = false;
        isropemake = false;
        power = MainManager.powerRes;
        power = 1 + power / 10f;
        luck = MainManager.luckRes;
        shield = MainManager.shieldRes;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (transform.parent.GetComponent<Rigidbody2D>().velocity.y > 0f)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y < 0.9f)
            {
                notclick = true;
                Time.timeScale = 0.2f;
                Time.fixedDeltaTime *= 0.2f;
                Time.maximumDeltaTime *= 0.2f;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else notclick = false;
        }
        if (Input.GetMouseButton(0) && notclick)
        {
            targetpos = Input.mousePosition;
            targetpos = Camera.main.ScreenToWorldPoint(targetpos);
            targetpos = targetpos - (Vector2)transform.parent.position;
            transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, targetpos);
            transform.GetChild(0).GetComponent<LineRenderer>().material.mainTextureScale =
                new Vector2(Vector2.Distance(transform.GetChild(0).GetComponent<LineRenderer>().GetPosition(0),
                transform.GetChild(0).GetComponent<LineRenderer>().GetPosition(1)) * 10, 1);

        }
        if (Input.GetMouseButtonUp(0) && notclick)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime *= 5f;
            Time.maximumDeltaTime *= 5f;
            transform.GetChild(0).gameObject.SetActive(false);
            if (targetpos.y > 0)
            {
                shot();
            }
        }

        if(ismove)
        {
            if(transform.parent.childCount>1&& transform.parent.GetComponent<Rigidbody2D>().velocity.y<=0)
            {
                Destroy(transform.parent.GetChild(1).gameObject);
            }
        }
        
        
        if(isforce)
        {
            isforce = false;
            Vector2 pos = transform.parent.GetChild(1).GetComponent<Rope>().endpos;
            transform.parent.GetComponent<Rigidbody2D>().AddForce((pos + new Vector2(0, 3)) * 200f * power);
        }

        if (rope && rope.GetComponent<LineRenderer>().GetPosition(1).y -
            rope.GetComponent<LineRenderer>().GetPosition(0).y < 0)
        {
            Destroy(rope);
        }

        if (transform.parent.GetComponent<Rigidbody2D>().velocity.y > 30f*power)
            transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(
                transform.parent.GetComponent<Rigidbody2D>().velocity.x, 30f*power);

        if(isdie)
        {
            if (time <= 3f)
            {
                isdie = false;
            }
            else if (Random.Range(0,20)>luck)
            {
                if (time > 3f && shield >= 1)
                {
                    time = 0;
                    shield--;
                    isdie = false;
                    StartCoroutine(dieEffect());
                }
                else if (time > 3f && shield < 1)
                {
                    if (Time.timeScale == 0.2f)
                    {
                        Time.timeScale = 1f;
                        Time.fixedDeltaTime *= 5f;
                        Time.maximumDeltaTime *= 5f;
                    }
                    if (GameObject.Find("GameManager"))
                    {
                        GameObject.Find("GameManager").GetComponent<CharacterData>().Coin_ = (int.Parse(GameObject.Find("GameManager").GetComponent<CharacterData>().Coin_) + ((int)transform.parent.position.y)/10).ToString();
                    }
                    dieparticle.transform.position = transform.parent.position + new Vector3(0, 0, -2);
                    dieparticle.gameObject.SetActive(true);
                    ResultPanel.SetActive(true);
                    transform.parent.gameObject.SetActive(false);
                }
            }
            else if(Random.Range(0,20)<=luck)
            {
                isdie = false;
                StartCoroutine(luckEffect());
                time = 0;
            }
        }
    }

    public void shot()
    {
        if (iscol)
        {
            if (isbool && transform.parent.childCount == 1)
            {
                ismove = false;
                iscol = false;
                isropemake = true;
                rope = new GameObject("rope");
                rope.transform.position = transform.position;
                rope.transform.SetParent(transform.parent);
                rope.AddComponent<Rope>();
                rope.AddComponent<LineRenderer>();
            }
        }
        else
        {
            if (isropemake)
            {
                Destroy(rope);
                iscol = true;
                isbool = true;
                isropemake = false;
            }
        }
    }

    IEnumerator dieEffect()
    {
        int count = 0;
        while(count<12)
        {
            yield return new WaitForSeconds(0.25f);
            if (count % 2 == 0)
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
            else
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            count++;
        }
    }

    IEnumerator luckEffect()
    {
        int count = 0;
        while (count < 12)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            if (count < 8)
                transform.GetChild(2).gameObject.SetActive(true);
            else
                transform.GetChild(2).gameObject.SetActive(false);
            count++;
            yield return new WaitForSeconds(0.25f);
        }
        transform.GetChild(1).gameObject.SetActive(false);
    }
}