using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float attackRange = 1.5f;
    public float movementSpeed = 3f;
    public int attackDamage = 10;

    private Transform target;
    private NavMeshAgent agent;
    private bool isAttacking = false;

    private void Start()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
            agent = GetComponent<NavMeshAgent>();
            agent.speed = movementSpeed;
            agent.updateRotation = false;
        }
        else
        {
            Debug.LogWarning("Target object not found!");
        }
    }

    private void Update()
    {
        if (target != null && !isAttacking)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= attackRange)
            {
                // Saldýrma mesafesine ulaþýldý, karaktere saldýr
                Attack();
            }
            else if (distance <= agent.stoppingDistance)
            {
                // Durma mesafesine ulaþýldý, zombi karakteri dur
                agent.isStopped = true;
            }
            else
            {
                // Hedefe doðru hareket et
                agent.isStopped = false;
                MoveToTarget();
            }
        }
    }

    private void MoveToTarget()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        agent.SetDestination(targetPosition);
    }

    private void Attack()
    {
        // Burada karaktere saldýrma iþlemlerini gerçekleþtirin
        Debug.Log("Zombie is attacking!");

        // Saldýrma iþleminin tamamlanmasý için belirli bir süre bekleme yapabilirsiniz
        isAttacking = true;
        Invoke("FinishAttack", 2f);
    }

    private void FinishAttack()
    {
        isAttacking = false;
    }
}
