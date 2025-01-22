using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateyMaker : MonoBehaviour
{
    public GameObject prefab;
    public LandLubber[] landLubber;

    public bool roundSetup = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roundSetup)
        {
            recruitment();
        }
    }

    void recruitment()
    {
        LandLubber[] = null;
        roundSetup = false;
    }
}
