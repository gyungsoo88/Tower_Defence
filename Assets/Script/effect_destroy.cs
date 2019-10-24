using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_destroy : MonoBehaviour
{
    float time;
    public float life;
    void Update()
    {
        time += Time.deltaTime;
        if (time > life)
        {
            
            Destroy(gameObject);
        }
    }
}
