using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaa : MonoBehaviour
{
    LineRenderer linerenderer;
    Vector3 mousepos;

    bool isbool;
    void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos) + new Vector3(0, 0, 10) - transform.position;
        linerenderer.SetPosition(1, mousepos);
        linerenderer.material.mainTextureScale =
            new Vector2(Vector2.Distance(linerenderer.GetPosition(0), linerenderer.GetPosition(1))*10f, 1);
    }
}
