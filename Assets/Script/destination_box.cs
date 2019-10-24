using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destination_box : MonoBehaviour
{
    public int Box_no;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ai>()!=null)
        other.GetComponent<Ai>().SetDestination(Box_no + 1);
    }
}
