using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    
    int county;

    private void Awake()
    {
        float size = ((float)Screen.height / Screen.width)/(16/9f);
        Camera camera = GetComponent<Camera>();
        camera.orthographicSize = 10 * size;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(2.8f, player.transform.position.y + 5f, -10);
    }
}
