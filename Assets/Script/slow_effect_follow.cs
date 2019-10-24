using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_effect_follow : MonoBehaviour
{



    void Update()
    {
        if (transform.parent != null)
        {
            transform.position = transform.parent.position;
        }
    }
}
