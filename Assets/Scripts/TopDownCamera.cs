using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target; // Takip edilecek hedefin referansý
    public float distance = 5f; // Kamera ile hedef arasýndaki mesafe
    public float height = 5f; // Kamera yüksekliði

    void LateUpdate()
    {
        if (target == null)
            return;

        // Hedefin pozisyonunu al
        Vector3 targetPosition = target.position;

        // Kamerayý hedefin üstüne yerleþtir
        Vector3 cameraPosition = targetPosition - distance * Vector3.back + height * Vector3.up;

        // Kameranýn rotasyonunu ayarla
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Tepeden bakma açýsý için rotasyonu ayarla

        // Kameranýn pozisyonunu güncelle
        transform.position = cameraPosition;
    }
}
