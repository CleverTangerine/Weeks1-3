using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
    public float curveLength = 1;
    [Range(0, 1)]
    public float s;
    public AnimationCurve sway;
    [Range(0, 1)]
    public float b;
    public AnimationCurve bounce;
    [Range(0, 1)]
    public float mouseX;
    [Range(0, 1)]
    public float mouseY;
    Vector2 mousePos;
    public float offset = 0f;
    public int flip = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mouseX = mousePos.x / Screen.width;
        mouseY = mousePos.y / Screen.height;
        s = (s + 0.007f + Mathf.Abs(offset) / 1000) % 1;
        b = (s + 0.01f + Mathf.Abs(offset) / 1000) % 1;
        //Debug.Log(mousePos);
        Vector2 pos = transform.position;
        pos.x = (sway.Evaluate(s) + mouseX * 2) + offset;
        pos.y = bounce.Evaluate(b) + mouseY * 2 * flip;
        transform.position = pos;
    }
}
