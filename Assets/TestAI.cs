using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    NavMeshAgent agent;
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis= false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
