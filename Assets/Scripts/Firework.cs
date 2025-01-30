using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    // Curve for the fireworks rise
    [Range(0, 1)]
    public float r;
    public AnimationCurve rise;
    // Curve for the firework growing and shrinking
    // e starts to change in responce to r reaching a certain value
    [Range(0, 1)]
    public float e;
    public AnimationCurve expand;
    // Offset for y position
    public float height = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Running respawn at the start saves me some lines of code
        respawn();
    }

    // Update is called once per frame
    void Update()
    {
        // If the firework completes its animation, it'll reset and look like a new firework appeared
        if (r > 1)
        {
            respawn();
            //resets the animation curve
            r -= 1;
        }
        // size is a modifable vector to change the scale
        Vector2 size = transform.localScale;

        // When r is around 0.6, it starts to fall, which means the firework would've exploded
        if (r > 0.6f)
        {
            // After 0.6 but before 0.8, the curve is flat, and the firework hardly moves
            if (r < 0.8f)
            {
                e += Time.deltaTime * 0.6f;
            }
            // At 0.8, r is falling, and it needs to shrink by making e go backwards through the curve
            else
            {
                e -= Time.deltaTime * 2f;
            }
            
            // size variable gets its values from e
            size = Vector2.one * rise.Evaluate(e);
        }
        else
        {
            size = Vector2.one / 8;
        }
        transform.localScale = size;

        // pos is a modifable vector to change the position
        Vector2 pos = transform.position;
        // r increases over time
        r += Time.deltaTime * 0.15f;
        pos.y = rise.Evaluate(r) * 4;
        // The position is updated by pos
        transform.position = pos;
    }

    // The function is used to make the fireworks reset and look like theres a new one
    void respawn()
    {
        // Height is the random intial y offset it will use
        height = Random.Range(2f, 4f);
        // pos is a modifable vector to change the position
        Vector2 pos = transform.position;
        // picks a random point on the screen to make the firework
        pos.x = Random.Range(Screen.width / -210f, Screen.width / 210f);
        pos.y = Screen.height / -2 + height;
        // The position is updated by pos
        transform.position = pos;
        // Variables reset
        e = 0;
        transform.localScale = Vector2.one;
    }
}
