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
        Debug.Log("Zombie Basladý");
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
            agent = GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                Debug.Log("NavMash Bulundu");
            }
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

        var objectPositon = GameObject.FindGameObjectWithTag("Player").transform;
        var zombiObjectPositon = GameObject.FindGameObjectWithTag("Zombi").transform;
        Debug.Log(objectPositon);
        Debug.Log(zombiObjectPositon);


        zombiObjectPositon.position = Vector3.MoveTowards(zombiObjectPositon.position, (objectPositon.transform.position), .00113F);

    }

    private void MoveToTarget()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        agent.SetDestination(targetPosition);
    }

    private void Attack()
    {
        Debug.Log("Zombie is attacking!");

        isAttacking = true;
        Invoke("FinishAttack", 2f);
    }

    private void FinishAttack()
    {
        isAttacking = false;
    }
}
