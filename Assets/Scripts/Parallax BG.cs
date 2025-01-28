using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public float start = 20;
    public float end = 40;
    public bool offset = false;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (offset)
        {
            pos.x += Screen.width / 40;
        }
        Vector2 size = transform.localScale;
        size.x = Screen.width / 35;
        size.y = Screen.height / 35;
        transform.localScale = size;
        
        pos.x -= 3 * Time.deltaTime;
        Debug.Log(pos);
        Debug.Log(Screen.width);
        if (pos.x < -Screen.width / end + Screen.width / 800)
        {
            pos.x += Screen.width / start + Screen.width / 800;
        }
        transform.position = pos;
        if (offset)
        {
            pos.x -= Screen.width / 40;
        }
    }
}
