using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AIZombie : MonoBehaviour
{
    public AudioSource zombieDie;
    public AudioSource zombieHit;
    [SerializeField] private GameObject player;
    [SerializeField] private float attackRange;
    [SerializeField] private float activationRange;
    [SerializeField] private float speed;

    private NavMeshAgent _navMesh;
    private Animator _animator;
    internal bool HasAttack;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        var distance = Vector3.Distance(transform.position, player.transform.position);
        // print(distance);

        _animator.SetFloat("Speed", speed);
        if (distance < activationRange) SetTarget();


        if (distance <= attackRange)
        {
            _navMesh.speed = 0;
            PlayAnim("Attack", 2633);
        }
        else
        {
            _navMesh.speed = speed;
        }
    }

    private void SetTarget()
    {
        _navMesh.SetDestination(player.transform.position);
    }

    private async void PlayAnim(string animationType, int duration)
    {
        if (HasAttack) return;
        HasAttack = true;
        zombieHit.Play();
        _animator.SetBool(animationType, true);
        await Task.Delay(duration);
        _animator.SetBool(animationType, false);
        HasAttack = false;
    }
    public void Die()
    {
        zombieDie.Play();
        gameObject.SetActive(false);
    }
}