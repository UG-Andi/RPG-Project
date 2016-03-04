using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // Referenzen
    private NavMeshAgent navMeshAgent;
    private GameObject player;

    [Header("Settings")]
    public float speed;
    public float distance;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player");

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            Vector3 lookDir = player.transform.position - transform.position;
            Quaternion.LookRotation(lookDir);

            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}