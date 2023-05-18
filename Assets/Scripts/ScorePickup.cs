using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Karakter nesnesine de�di�inde skoru art�r
            ScoreManager.Instance.AddScore(scoreValue);

            // Nesneyi yok et
            Destroy(gameObject);
        }
    }
}
