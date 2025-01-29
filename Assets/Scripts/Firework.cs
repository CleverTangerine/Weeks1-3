using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [Range(0, 1)]
    public float r;
    public AnimationCurve rise;
    [Range(0, 1)]
    public float e;
    public AnimationCurve expand;
    public float height = 0;
    // Start is called before the first frame update
    void Start()
    {
        respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (r > 1)
        {
            respawn();
            r -= 1;
        }
        if(r > 0.6f)
        {
            Vector2 size = transform.localScale;
            if (r > 0.8f)
            {
                e -= Time.deltaTime * 2f;
            }
            else
            {
                e += Time.deltaTime * 0.6f;
            }
            
            size = Vector2.one * rise.Evaluate(e) * height;
            transform.localScale = size;
            Debug.Log(rise.Evaluate(e));
        }
        Vector2 pos = transform.position;
        r += Time.deltaTime * 0.15f;
        pos.y = rise.Evaluate(r) * 4;
        transform.position = pos;
    }

    void respawn()
    {
        height = Random.Range(3f, 4f);
        Vector2 pos = transform.position;
        pos.x = Random.Range(Screen.width / -210f, Screen.width / 210f);
        pos.y = Screen.height / 4;
        transform.position = pos;
        e = 0;
        transform.localScale = Vector2.one;
        //Debug.Log(Screen.width / -210 + " " + Screen.width / 210);
    }
}
