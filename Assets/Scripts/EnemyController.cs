using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target; //player
    [SerializeField] float chaseramge = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false; 

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); //distance between zombie and player

        if (isProvoked)
        {
            Engagetarget();
        }
        else if (distanceToTarget <= chaseramge)
        {
            isProvoked = true;
        }
    }

    void Engagetarget() //responsible for controlling all the states EG: attacking and chasing
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) //checking if your inside the range to chase
        {
             Chasetarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)// checks to see if your inside the attack range
        {
            AttackTarget();
        }
    }

    void Chasetarget() //responsable for chasing the player
    {
        navMeshAgent.SetDestination(target.position); //if distance is less then chase range then follow player
    }

    void AttackTarget() // responsible for attacking the target
    {
        Debug.Log(name + "is attacking " + target.name);
    }


    void OnDrawGizmosSelected() //shows visual chase range gizmo basiclly aoe of chace range if you remvoe the seleced then it shows all the time exluding in game 
    {
        Gizmos.color = Color.red; //sets the colour of the AOE
        Gizmos.DrawWireSphere(transform.position, chaseramge); //draws the actual AOE
    }
}
