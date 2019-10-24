using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{


        void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bigone")
        {
            Destroy(other.gameObject);
            GameManager.instance.core_hp -= 30;
            GameManager.instance.core_info.text = "Core HP " + GameManager.instance.core_hp;
        }
        else if(other.tag == "smallone")
        {
            GameManager.instance.core_hp -= 5;
            GameManager.instance.core_info.text = "Core HP " + GameManager.instance.core_hp;
            Destroy(other.gameObject);
        }
        else if (other.tag == "hugeone")
        {
            GameManager.instance.core_hp -= 100;
            GameManager.instance.core_info.text = "Core HP " + GameManager.instance.core_hp;
            Destroy(other.gameObject);
        }
    }
}
