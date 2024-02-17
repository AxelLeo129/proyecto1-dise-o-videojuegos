using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform target; // Asigna el otro enemigo como objetivo en el Inspector

    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // void Update()
    // {
    //     agent.SetDestination(target.position);
    // }
    void Update()
    {
        agent.SetDestination(target.position);

        // Aquí se corrige la rotación
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            // Vector3 direction = (target.position - transform.position).normalized;
            Vector3 direction = (transform.position - target.position).normalized; // Invertir esta línea
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
        }
    }

}
