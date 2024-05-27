using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundInit : MonoBehaviour
{
    static bool initialized = false;
    void Awake()
    {
        if (!initialized)
        {
            DontDestroyOnLoad(gameObject);
            initialized = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
