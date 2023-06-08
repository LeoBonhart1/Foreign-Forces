using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _counter;

    private void OnEnable()
    {
        _counter = 4;
    }

    private void Update()
    {
        Counter();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (!other.gameObject.CompareTag("Zombi")) return;
        other.gameObject.GetComponent<AIZombie>().Die();
        Destroy(gameObject);
    }

    private void Counter()
    {
        _counter -= Time.deltaTime;
        if (_counter > 0) return;
        Destroy(gameObject);
    }
}