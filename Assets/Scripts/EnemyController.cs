using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    PlayerHealth target; //player
    [SerializeField] float chaseramge = 10f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    Animator animator;
    NavMeshAgent navMeshAgent;
    EnemyHealth enemyHelath;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        target = FindFirstObjectByType<PlayerHealth>();
        enemyHelath = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (enemyHelath.IsDead()) //disables the enemy controller if enemy is dead
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.transform.position, transform.position); //distance between zombie and player

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
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.transform.position); //if distance is less then chase range then follow player
    }

    void AttackTarget() // responsible for attacking the target
    {
        animator.SetBool("Attack", true);
    }

    public void OnDamageTaken() //this is making it so when the enemy takes damage they chase them 
    {
        isProvoked = true;
    }


    void OnDrawGizmosSelected() //shows visual chase range gizmo basiclly aoe of chace range if you remvoe the seleced then it shows all the time exluding in game 
    {
        Gizmos.color = Color.red; //sets the colour of the AOE
        Gizmos.DrawWireSphere(transform.position, chaseramge); //draws the actual AOE
    }
}
