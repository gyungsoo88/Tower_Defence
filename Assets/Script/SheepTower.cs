using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepTower : MonoBehaviour
{
    public GameObject smallone;
    public GameObject largeone;
    public GameObject effect1;
    public GameObject firebeam;
    public GameObject fire1;
    public GameObject fire2;
    bool trigger = true;

    float time = 0;


    void Update()
    {
        if (GameManager.instance.wave_on)
        {
            time += Time.deltaTime;
            if (time > 5&&trigger)
            {

                time = 0;
                if (GameManager.instance.sheep_upgrade == 1)
                {
                    var test = fire1.GetComponent<ParticleSystem>().main;
                    test.startColor = Color.yellow;
                    var test2 = fire2.GetComponent<ParticleSystem>().main;
                    test2.startColor = Color.yellow;
                }
                if (GameManager.instance.sheep_upgrade == 2)
                {
                    var test = fire1.GetComponent<ParticleSystem>().main;
                    test.startColor = Color.green;
                    var test2 = fire2.GetComponent<ParticleSystem>().main;
                    test2.startColor = Color.green;
                }
                if (GameManager.instance.sheep_upgrade == 3)
                {
                    var test = fire1.GetComponent<ParticleSystem>().main;
                    test.startColor = Color.white;
                    var test2 = fire2.GetComponent<ParticleSystem>().main;
                    test2.startColor = Color.white;
                }

                firebeam.SetActive(true);
                GetComponent<BoxCollider>().enabled = true;
                trigger = false;

            }
            if(time>1&&!trigger)
            {
                time = 0;

                firebeam.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;
                trigger = true;
            }
        }
        else
        {
            firebeam.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ignore")
            return;
        if (other.tag != "Unbreakable")
        {
            if (other.tag == "Hugeone")
            {
                if (other.GetComponent<Ai>().hp < 20 + 20*GameManager.instance.sheep_upgrade)
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
                    other.GetComponent<Ai>().hp -= 20 + 20*GameManager.instance.sheep_upgrade;

                    return;
                }

            }
            if (other.tag == "Bigone")
            {
                if (other.GetComponent<Ai>().hp < 20 + 20*GameManager.instance.sheep_upgrade)
                {
                    float i = other.transform.position.x;
                    float j = other.transform.position.y;
                    float k = other.transform.position.z;

                    Instantiate(effect1, other.transform.position, Quaternion.identity);
                    GameManager.instance.explosion1_sound();

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
                    other.GetComponent<Ai>().hp -= 20+20*GameManager.instance.sheep_upgrade;

                    return;
                }
            }
            else if (other.tag == "smallone")
            {
                if (other.GetComponent<Ai>().hp <= 20 + 20*GameManager.instance.sheep_upgrade)
                {
                    Destroy(other.gameObject);
                    GameManager.instance.explosion1_sound();
                    Instantiate(effect1, other.transform.position, Quaternion.identity);
                    GameManager.instance.energy += 5;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                }
                else
                {
                    other.GetComponent<Ai>().hp -= 20 + 20*GameManager.instance.sheep_upgrade;
                   
                    return;
                }
            }
        }

        else
            Instantiate(effect1, transform.position, Quaternion.identity);

    }

}
