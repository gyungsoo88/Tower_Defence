using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float time=0;
    int spawn_count = 0;
    public GameObject armored_s;
    public GameObject armored_m;
    public GameObject armored_l;
    public GameObject spawn_effect;
    void Update()
    {

        if(!GameManager.instance.wave_on&& Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.wave_on = true;
            GameManager.instance.Center_info.enabled = false;
            GameManager.instance.wave_spawn = true;
        }


        if (GameManager.instance.wave_on)
        {

            if (GameManager.instance.stage == 1 && GameManager.instance.wave_spawn)
            {
                time += Time.deltaTime;
                if (time > 2)
                {
                    Instantiate(GameManager.instance.small, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    Instantiate(spawn_effect, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    time = 0;

                    ++spawn_count;
                }
                if (spawn_count > 10)
                {
                    spawn_count = 0;
                    GameManager.instance.wave_spawn = false;
                }
            }
            else if (GameManager.instance.stage == 2 && GameManager.instance.wave_spawn)
            {
                time += Time.deltaTime;
                if (time > 1)
                {
                    Instantiate(GameManager.instance.small, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    Instantiate(spawn_effect, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    time = 0;

                    ++spawn_count;
                }
                if (spawn_count > 20)
                {
                    spawn_count = 0;
                    GameManager.instance.wave_spawn = false;
                }
            }
            else if (GameManager.instance.stage == 3 && GameManager.instance.wave_spawn)
            {
                time += Time.deltaTime;
                if (time > 2)
                {
                    Instantiate(GameManager.instance.medium, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    Instantiate(spawn_effect, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    time = 0;

                    ++spawn_count;
                }
                if (spawn_count > 5)
                {
                    spawn_count = 0;
                    GameManager.instance.wave_spawn = false;
                }

            }
            else if (GameManager.instance.stage == 4 && GameManager.instance.wave_spawn)
            {
                time += Time.deltaTime;
                if (time > 1)
                {
                    Instantiate(GameManager.instance.medium ,new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    Instantiate(spawn_effect, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    time = 0;

                    ++spawn_count;
                }
                if (spawn_count > 10)
                {
                    spawn_count = 0;
                    GameManager.instance.wave_spawn = false;
                }

            }
            else if (GameManager.instance.stage > 9 && GameManager.instance.wave_spawn)
            {
                time += Time.deltaTime;
                int a = GameManager.instance.stage;
                if (time > 1)
                {
                    Instantiate(GameManager.instance.large, new Vector3(transform.position.x, 4, transform.position.z), Quaternion.identity);
                    Instantiate(spawn_effect, new Vector3(transform.position.x, 4, transform.position.z), Quaternion.identity);
                    time = 0;

                    ++spawn_count;
                }
                if (spawn_count > 5 * (a - 8))
                {
                    spawn_count = 0;
                    GameManager.instance.wave_spawn = false;
                }

            }

            else if (GameManager.instance.stage > 4 && GameManager.instance.wave_spawn)
            {
                time += Time.deltaTime;
                int a = GameManager.instance.stage;
                if (time > 1)
                {
                    Instantiate(GameManager.instance.large, new Vector3(transform.position.x, 4, transform.position.z), Quaternion.identity);
                    Instantiate(spawn_effect, new Vector3(transform.position.x, 4, transform.position.z), Quaternion.identity);
                    time = 0;

                    ++spawn_count;
                }
                if (spawn_count > 5 * (a - 3))
                {
                    spawn_count = 0;
                    GameManager.instance.wave_spawn = false;
                }

            }

            if (GameManager.instance.stage == 10)
            {
                GameManager.instance.small = armored_s;
                GameManager.instance.medium = armored_m;
                GameManager.instance.large = armored_l;

            }
        }






       
       
        
    }
}
