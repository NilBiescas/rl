using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkerNPPC : MonoBehaviour
{
    private NavMeshAgent agent;
    public float wanderRadius = 5f;

    public float minX = -13f;
    public float maxX = 13f;
    public float minZ = -13f;
    public float maxZ = 13f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public wander ()
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDir = Random.insideUnitSphere * dist;
        randDir += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, dist, layermask);
        return navHit.position;
    }
    public void SetRandomIntitialPosition()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        Vector3 parentPosition = transform.parent.position;
        transform.position = new Vector3(parentPosition.x + x, parentPosition.y, parentPosition.z + z);
        
    }
}

