using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform player;

    private float distanceToEnemy;
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
        //Vector3 targetVector = player.transform.position;
        targetVector = Vector3.Lerp(player.transform.position, transform.position, 0.5f);

        if (player.transform.position == null)
        {
            Debug.Log("Could not get " + player.gameObject.tag);
        }
        if (true){
            if (distanceToEnemy < 0){
                _navMeshAgent.SetDestination(targetVector);
                _navMeshAgent.updateRotation = false;
                //transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
            }
            else {
                _navMeshAgent.SetDestination(targetVector);
                _navMeshAgent.updateRotation = false;
                //transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
            }
        }
    }
}