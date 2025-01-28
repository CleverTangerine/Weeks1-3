using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandLubber : MonoBehaviour
{
    public Vector2 mousePos;
    public SpriteRenderer spriteRenderer;
    public bool inspection = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(-3f, 3f);
        pos.y = Random.Range(-3f, 3f);
        pos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
            if (spriteRenderer.bounds.Contains(mousePos))
            {
                if(Random.Range(0f, 2f) > 1)
                {
                    inspection = true;
                }
                else
                {
                    //MateyMaker.
                }
            }
        }
    }
}
