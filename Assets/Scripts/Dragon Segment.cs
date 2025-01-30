using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
    // Curve for a horizontal sway
    [Range(0, 1)]
    public float s;
    public AnimationCurve sway;
    // Curve for a vertical bounce
    [Range(0, 1)]
    public float b;
    public AnimationCurve bounce;
    // Constrained mouse position to keep the Dragon on screen
    [Range(0, 1)]
    public float mouseX;
    [Range(0, 1)]
    public float mouseY;
    // A vector made up of the mouseX/Y
    Vector2 mousePos;
    // Offsets the animations to make each segment unique
    public float offset = 0f;
    // Int that flips the Vertical movements, can either be 1 or -1
    public int flip = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Getting the mouse position and mapping it to the size of the screen
        mousePos = Input.mousePosition;
        mouseX = mousePos.x / Screen.width;
        mouseY = mousePos.y / Screen.height;
        // Increases the curves by using the offset, scaled down to fit the Range
        s = (s + 0.7f * Time.deltaTime + Mathf.Abs(offset) / 2000) % 1;
        b = (s + 0.76f * Time.deltaTime + Mathf.Abs(offset) / 2000) % 1;
        // pos is a modifable vector to change the position
        Vector2 pos = transform.position;
        // Getting all of the positon changes and inputting it into transform
        pos.x = (sway.Evaluate(s) + mouseX * 2) + offset;
        pos.y = bounce.Evaluate(b) + mouseY * 2 * flip - 2;
        transform.position = pos;
    }
}
