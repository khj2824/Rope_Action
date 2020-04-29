using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public RectTransform List;
    public int count;
    public MainManager mainmanager;
    private float pos;
    private float movepos;
    private bool isScroll = false;

    void Start()
    {
        pos = List.localPosition.x;
        movepos = List.rect.xMax - List.rect.xMax / count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Right()
    {
        if (List.rect.xMin + List.rect.xMax / count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos - List.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
            mainmanager.count++;
        }
    }

    public void Left()
    {
        if (List.rect.xMax - List.rect.xMax / count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos + List.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
            mainmanager.count--;
        }
    }

    IEnumerator scroll()
    {
        while (isScroll)
        {
            List.localPosition = Vector2.Lerp(List.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
            if (Vector2.Distance(List.localPosition, new Vector2(movepos, 0)) < 0.1f)
            {
                isScroll = false;
            }
            yield return null;
        }
    }
}
