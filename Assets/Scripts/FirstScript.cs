using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Vector2(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed;
        Vector2 squareInScreenSpace = Camera.main.WorldToScreenPoint(pos);

        if((squareInScreenSpace.x < 0 && speed < 0) || (squareInScreenSpace.x > Screen.width && speed > 0))
        {
            speed *= -1;
        }

        transform.position = pos;
    }
}
