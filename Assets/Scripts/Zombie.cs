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
                // Sald�rma mesafesine ula��ld�, karaktere sald�r
                Attack();
            }
            else if (distance <= agent.stoppingDistance)
            {
                // Durma mesafesine ula��ld�, zombi karakteri dur
                agent.isStopped = true;
            }
            else
            {
                // Hedefe do�ru hareket et
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
        // Burada karaktere sald�rma i�lemlerini ger�ekle�tirin
        Debug.Log("Zombie is attacking!");

        // Sald�rma i�leminin tamamlanmas� i�in belirli bir s�re bekleme yapabilirsiniz
        isAttacking = true;
        Invoke("FinishAttack", 2f);
    }

    private void FinishAttack()
    {
        isAttacking = false;
    }
}
