using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{

    public GameObject _destination ;
  

    NavMeshAgent _navMeshagent;
    public int hp = 3;
    public bool target_serach=false;

    // Use this for initialization
    public void Start()
    {
        _navMeshagent = this.GetComponent<NavMeshAgent>();

        if (_navMeshagent == null)
        {
            Debug.LogError("Nav Mesh Agent component not found attached to " + gameObject.name);
        }
        else
        {
            SetDestination(0);
        }
    }

    public void SetDestination(int index)
    {
        if (_destination != null)
        {
            Vector3 targetVector = new Vector3(_destination.transform.position.x,0, _destination.transform.position.z);
            _navMeshagent.SetDestination(targetVector);
        }
    }
}   