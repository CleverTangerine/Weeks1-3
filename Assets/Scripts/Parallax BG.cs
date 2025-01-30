using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    // Boolean to check whether or not this object will have an offset
    public bool offset = false;
    // pos is a modifable vector to change the position
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        // pos is set to (0,0,0) to always stay in the middle when the game starts
        pos = Vector2.zero;
        // Check for the offset
        if (offset)
        {
            pos.x += Screen.width / 40f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // size is a modifable vector to change the scale
        Vector2 size = transform.localScale;
        // size is set to the size of the screen
        size.x = Screen.width / 800f;
        size.y = Screen.height / 800f;
        transform.localScale = size;
        
        // pos increases over time
        pos.x -= 3f * Time.deltaTime;
        
        // Makes the object loop around the screen to maintian the parallax effect
        if (pos.x < -Screen.width / 40f)
        {
            pos.x += Screen.width / 20f;
            //Debug.Log(pos);
        }
        transform.position = pos;
    }
}
