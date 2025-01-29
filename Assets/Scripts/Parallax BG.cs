using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public bool offset = false;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        pos = Vector2.zero;
        if (offset)
        {
            pos.x += Screen.width / 40f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 size = transform.localScale;
        size.x = Screen.width / 40f;
        size.y = Screen.height / 40f;
        transform.localScale = size;
        
        pos.x -= 3f * Time.deltaTime;
        
        if (pos.x < -Screen.width / 40f)
        {
            pos.x += Screen.width / 20f;
            //Debug.Log(pos);
        }
        transform.position = pos;
    }
}
