using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mole_tower : MonoBehaviour
{
    public GameObject effect1;
    public GameObject color_object;
    GameObject effect_follow;

    private void Update()
    {

        if (GameManager.instance.mole_upgrade == 1)
        {
            var test = color_object.GetComponent<ParticleSystem>().main;
            test.startColor = Color.red;

        }
        if (GameManager.instance.mole_upgrade == 2)
        {
            var test = color_object.GetComponent<ParticleSystem>().main;
            test.startColor = Color.green;

        }
        if (GameManager.instance.mole_upgrade == 3)
        {
            var test = color_object.GetComponent<ParticleSystem>().main;
            test.startColor = Color.white;

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
                
                if(GameManager.instance.mole_upgrade==0)
                other.GetComponent<NavMeshAgent>().speed = 10;
                else if (GameManager.instance.mole_upgrade == 1)
                    other.GetComponent<NavMeshAgent>().speed = 5f;
                else if (GameManager.instance.mole_upgrade == 2)
                    other.GetComponent<NavMeshAgent>().speed = 2.5f;
                else if (GameManager.instance.mole_upgrade == 3)
                    other.GetComponent<NavMeshAgent>().speed = 1.25f;
                effect_follow= Instantiate(effect1, other.transform.position, Quaternion.identity);
                effect_follow.transform.parent = other.transform;



            }
            if (other.tag == "Bigone")
            {
                if (GameManager.instance.mole_upgrade == 0)
                    other.GetComponent<NavMeshAgent>().speed = 15f;
                else if (GameManager.instance.mole_upgrade == 1)
                    other.GetComponent<NavMeshAgent>().speed = 7.5f;
                else if (GameManager.instance.mole_upgrade == 2)
                    other.GetComponent<NavMeshAgent>().speed = 3.75f;
                else if (GameManager.instance.mole_upgrade == 3)
                    other.GetComponent<NavMeshAgent>().speed = 1.9f;
                effect_follow = Instantiate(effect1, other.transform.position, Quaternion.identity);
                effect_follow.transform.parent = other.transform;
            }
            else if (other.tag == "smallone")
            {
                if (GameManager.instance.mole_upgrade == 0)
                    other.GetComponent<NavMeshAgent>().speed = 30;
                else if (GameManager.instance.mole_upgrade == 1)
                    other.GetComponent<NavMeshAgent>().speed = 15f;
                else if (GameManager.instance.mole_upgrade == 2)
                    other.GetComponent<NavMeshAgent>().speed = 7.5f;
                else if (GameManager.instance.mole_upgrade == 3)
                    other.GetComponent<NavMeshAgent>().speed = 3.7f;
                effect_follow = Instantiate(effect1, other.transform.position, Quaternion.identity);
                effect_follow.transform.parent = other.transform;
            }
        }

            

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ignore")
            return;
        if (other.tag != "Unbreakable")
        {
            if (other.tag == "Hugeone")
            {
                other.GetComponent<NavMeshAgent>().speed = 20;
                Instantiate(effect1, transform.position, Quaternion.identity);

            }
            if (other.tag == "Bigone")
            {
                other.GetComponent<NavMeshAgent>().speed = 30;
                Instantiate(effect1, transform.position, Quaternion.identity);
            }
            else if (other.tag == "smallone")
            {
                other.GetComponent<NavMeshAgent>().speed = 60;
                Instantiate(effect1, transform.position, Quaternion.identity);
            }
        }
    }




}