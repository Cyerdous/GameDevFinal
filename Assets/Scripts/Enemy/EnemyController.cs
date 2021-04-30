using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        attackCooldown -= Time.deltaTime;

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance + 1)
            {
                //face the target
                FaceTarget();
                if(attackCooldown <= 0)
                {
                    Attack(target.gameObject.GetComponentInChildren<PlayerStats>());
                    attackCooldown = 1f / attackSpeed;
                }

            }
        }
    }
    public void Attack(CharacterStats targetStats)
    {
        Debug.Log("trying to attack");
        CharacterStats myStats = GetComponent<EnemyStats>();
        targetStats.TakeDamage(myStats.attackPower.GetValue());
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
