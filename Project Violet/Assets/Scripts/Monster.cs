using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public enum MonsterStates
{
    Wait, Patrol, Chase, Search
}
public class Monster : MonoBehaviour
{
    MonsterStates state;
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] Transform player;
    [SerializeField] Transform[] patrolPoints;
    [Min(1)][SerializeField] private float waitTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetState(MonsterStates.Patrol);
    }

    // Update is called once per frame

    void Update()
    {
        /* agent.SetDestination(player.position);
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
        }*/
        Looking();
        bool isMoving = agent.hasPath && agent.remainingDistance > agent.stoppingDistance;
        animator.SetBool("isWalking", isMoving);
        switch (state)
        {
            case MonsterStates.Wait:
                break;
            case MonsterStates.Patrol:
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.velocity.sqrMagnitude < 0.01f)
                {
                    SetState(MonsterStates.Wait);
                }
                break;
            case MonsterStates.Chase:
                agent.SetDestination(player.position);
                break;
            case MonsterStates.Search:
                break;
        }
    }
    public void SetState(MonsterStates newState)
    {
        switch (newState)
        {
            case MonsterStates.Wait:
                StartCoroutine(Waiting());
                break;
            case MonsterStates.Patrol:
                agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
                break;
            case MonsterStates.Chase:
                break;
            case MonsterStates.Search:
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    SetState(MonsterStates.Wait);
                }
                break;
        }
        state = newState;
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        SetState(MonsterStates.Patrol);
    }
    public void Looking()
    {
        if (!Physics.Linecast(transform.position, player.position))
        {
            SetState(MonsterStates.Chase);
        }
        else
        {
            if (!state.Equals(MonsterStates.Chase))
                return;
            SetState(MonsterStates.Search);
        }
    }
}