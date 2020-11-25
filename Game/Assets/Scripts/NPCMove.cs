using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform player;

    private bool inRange;
    private Vector3 targetVector;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.Log("Nav mesh agent component is not attatched to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    void Update()
    {
       SetDestination();
    }

    private void SetDestination()
    {
        //get the target vector position
        Vector3 targetVector = player.transform.position;

        if (player.transform.position == null)
        {
            Debug.Log("Could not get " + player.gameObject.tag);
        }
        if (true){
            _navMeshAgent.SetDestination(targetVector);
            _navMeshAgent.updateRotation = false;
            transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player") {
    //        inRange = true;
    //    }
    //}
}