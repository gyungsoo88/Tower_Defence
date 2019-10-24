using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_tower : MonoBehaviour
{
    public GameObject laser_round;
    GameObject laser_projectile;
    float time;
    float time_compare =0.2f;
    int round=0;

    void Update()
    {
        if (GameManager.instance.wave_on)
        {
            time += Time.deltaTime;
            if (time > time_compare)
            {
                time_compare = 0.05f;
                GameManager.instance.laser_projectile1_sound();
                laser_projectile = Instantiate(laser_round, new Vector3(transform.position.x + 5 + 2*(round - 1.5f), 8, transform.position.z+2*(round-1.5f)), transform.rotation);
                if (GameManager.instance.duck_upgrade == 1)
                {
                    laser_projectile.GetComponent<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.blue;
                }
                else if (GameManager.instance.duck_upgrade == 2)
                {
                    laser_projectile.GetComponent<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.green;
                }
                else if (GameManager.instance.duck_upgrade == 3)
                {
                    laser_projectile.GetComponent<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.white;
                }
                ++round;
                if (round >3)
                {
                    time_compare = 5;
                    round = 0;
                }

                time = 0;
            }
        }

    }
}
