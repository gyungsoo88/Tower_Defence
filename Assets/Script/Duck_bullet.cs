using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_bullet : MonoBehaviour
{
    public GameObject effect1;


      void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ignore")
            return;
        Destroy(gameObject);
        if (other.tag != "Unbreakable")
        {
            if (other.tag == "Hugeone")
            {
                if (other.GetComponent<Ai>().hp <= 20+ 20 * GameManager.instance.duck_upgrade)
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
                    other.GetComponent<Ai>().hp -= 20 + 20 * GameManager.instance.duck_upgrade;

                    return;
                }

            }
            if (other.tag == "Bigone")
            {
                if (other.GetComponent<Ai>().hp <=20+ 20 * GameManager.instance.duck_upgrade)
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
                    other.GetComponent<Ai>().hp -= 20 + 20 * GameManager.instance.duck_upgrade;

                    return;
                }
            }
            else if (other.tag == "smallone")
            {
                if (other.GetComponent<Ai>().hp <= 20 +20 * GameManager.instance.duck_upgrade)
                {
                    GameManager.instance.explosion1_sound();

                    Destroy(other.gameObject);
                    Instantiate(effect1, other.transform.position, Quaternion.identity);
                    GameManager.instance.energy += 5;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                }
                else
                {
                    other.GetComponent<Ai>().hp -= 20 + 20    *GameManager.instance.duck_upgrade;

                    return;
                }
            }
        }
  
        else
        Instantiate(effect1,transform.position, Quaternion.identity);

    }
    void Start()
    {
        transform.Rotate(0, 90, 0);
    }
    

   
}
