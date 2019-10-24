using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasser : MonoBehaviour
{
    public GameObject effect1;
    float time;
    float time2;
    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }


    void OnTriggerStay(Collider other)
    {
        if (GetComponent<MeshRenderer>().enabled)
        {
            

            if (other.tag != "Unbreakable")
            {
               

                if (other.tag =="Hugeone")
                {
                    if (other.GetComponent<Ai>().hp <= 1 + GameManager.instance.main_weapon_upgrade)
                    {
                        Instantiate(effect1, other.transform.position, Quaternion.identity);
                        GameManager.instance.explosion1_sound();

                        float i = other.transform.position.x;
                        float j = other.transform.position.y;
                        float k = other.transform.position.z;


                        Instantiate(GameManager.instance.medium, new Vector3(i, j, k), Quaternion.identity);
                        Instantiate(GameManager.instance.medium, new Vector3(i + 8, j, k + 8), Quaternion.identity);
                        Instantiate(GameManager.instance.medium, new Vector3(i - 8, j, k - 8), Quaternion.identity);

                        GameManager.instance.energy += 50;
                        GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                        Destroy(other.gameObject);

                        

                    }
                    else
                    {
                        other.GetComponent<Ai>().hp -= 1+GameManager.instance.main_weapon_upgrade;
                        return;
                    }

                }
                if (other.tag == "Bigone")
                {
                    if (other.GetComponent<Ai>().hp <= 1 + GameManager.instance.main_weapon_upgrade)
                    {
                        Instantiate(effect1, other.transform.position, Quaternion.identity);
                        GameManager.instance.explosion1_sound();

                        float i = other.transform.position.x;
                        float j = other.transform.position.y;
                        float k = other.transform.position.z;


                        Instantiate(GameManager.instance.small, new Vector3(i, j, k), Quaternion.identity);
                        Instantiate(GameManager.instance.small, new Vector3(i + 4, j, k + 4), Quaternion.identity);
                        Instantiate(GameManager.instance.small, new Vector3(i + 8, j, k + 8), Quaternion.identity);
                        Instantiate(GameManager.instance.small, new Vector3(i - 4, j, k - 4), Quaternion.identity);
                        Instantiate(GameManager.instance.small, new Vector3(i - 8, j, k - 8), Quaternion.identity);

                        Instantiate(GameManager.instance.small, other.transform.position, Quaternion.identity);

                        GameManager.instance.energy += 20;
                        GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                        Destroy(other.gameObject);

                    }
                    else
                    {
                        other.GetComponent<Ai>().hp -= 1 + GameManager.instance.main_weapon_upgrade;
                        return;
                    }


                }
                else if (other.tag == "smallone")
                {
                    if (other.GetComponent<Ai>().hp <= 1 + GameManager.instance.main_weapon_upgrade)
                    {
                        Instantiate(effect1, other.transform.position, Quaternion.identity);
                        GameManager.instance.explosion1_sound();
                        Destroy(other.gameObject);
                        Instantiate(effect1, other.transform.position, Quaternion.identity);
                        GameManager.instance.energy += 5;
                        GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                    }
                    
                    else
                    {
                        GameManager.instance.explosion1_sound();
                        other.GetComponent<Ai>().hp -= 1 + GameManager.instance.main_weapon_upgrade;
                        return;
                    }
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MeshRenderer>().enabled)
        {

            time += Time.deltaTime;
            if (time > 0.1f)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                time = 0;

            }
        }
        else
        {
            time += Time.deltaTime;
            if (time > 0.1f)
            {
                GameManager.instance.laser_on = false;
                time = 0;
            }
        }
    }
}

