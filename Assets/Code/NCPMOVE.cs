using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NCPMOVE : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    public float npcSpeed = 3.5f; // متغير لتحديد سرعة الـ NPC
    int waypointIndex;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = npcSpeed; // تعيين السرعة عند بدء التشغيل
        UpdateDestination();
    }

    void Update()
    {
        agent.speed = npcSpeed; // تحديث السرعة في كل إطار لتتغير ديناميكيًا
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
