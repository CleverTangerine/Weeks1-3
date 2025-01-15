using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicketClockTock : MonoBehaviour
{
    public float tickSpeed = 1;
    public float tickTimer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tickTimer += tickSpeed * Time.deltaTime;
        while (true)
        {
            if (Mathf.Abs(tickTimer) >= 1)
            {
                tickTimer = tickTimer % 1;
                Vector3 rot = transform.eulerAngles;
                rot.z -= tickSpeed / Mathf.Abs(tickSpeed);
                transform.eulerAngles = rot;
            }
            else break;
        }
        
        
        
    }
}
