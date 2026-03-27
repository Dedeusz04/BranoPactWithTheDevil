using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    [SerializeField] float stopdis;
    public NavMeshAgent agent;
    public Transform player;
    GameObject target;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float damage;
    public float health;
    public float attackCooldown = 2;
    public float lastAttackTime = 0;
    public float walkPointRange;
    public bool daleko;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public Animator attack;

    public float sightRange, attackRange;
    public bool playerinsightrange, playerinattackrange;

    private void Start()
    {
        target = GameObject.Find("Gracz");
    }
    private void Awake()
    {
        player = GameObject.Find("Gracz").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        float dis = Vector3.Distance(transform.position, target.transform.position);
        playerinsightrange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerinsightrange && !playerinattackrange) Patroling();
        if (playerinsightrange && !playerinattackrange) ChasePlayer();
        if (playerinsightrange && playerinattackrange && daleko) AttackPlayer();
        if (!daleko)
        {

            if (dis < stopdis)
            {
                agent.isStopped = true;
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    lastAttackTime = Time.time;
                    target.GetComponent<graczhp>().Obrazenie(damage);
                    Debug.Log("Dosta³eœ hita");
                }
            }
        }
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

        }
        Vector3 distancetoWalkPoint = transform.position - walkPoint;
        if (distancetoWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void ChasePlayer()
    {
        attack.SetTrigger("Chase");
        agent.isStopped = false;
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
    private void AttackPlayer()
    {
        attack.SetTrigger("Attack");

        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);









        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void StopEnemy()
    {
        agent.isStopped = true;
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

