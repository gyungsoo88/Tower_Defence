using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject laser_round;
    GameObject laser_projectile;
    float time;

    void Update()
    {
        if (GameManager.instance.wave_on)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                GameManager.instance.laser_projectile1_sound();
                laser_projectile = Instantiate(laser_round, new Vector3(transform.position.x + 5, 8, transform.position.z), transform.rotation);
                if (GameManager.instance.penguin_upgrade == 1)
                {
                    laser_projectile.GetComponent<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.blue;
                }
                else if (GameManager.instance.penguin_upgrade == 2)
                {
                    laser_projectile.GetComponent<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.green;
                }
                else if (GameManager.instance.penguin_upgrade == 3)
                {
                    laser_projectile.GetComponent<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.yellow;
                }

                time = 0;
            }
        }
            
    }
}
