using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PoolingManager _poolingManager;
    float counter;

    private void OnEnable()
    {
        counter = 4;
        _poolingManager = PoolingManager.Instance;
    }

    private void Update()
    {
        Counter();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombi"))
        {
            collision.gameObject.GetComponent<AIZombie>().Die();
            _poolingManager.BulletReturn(gameObject);
        }
    }

    private void Counter()
    {
        counter -= Time.deltaTime;
        print(counter);
        if (counter > 0) return;
        _poolingManager.BulletReturn(gameObject);
    }
}