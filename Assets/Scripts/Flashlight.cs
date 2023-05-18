using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlightPrefab;

    private Light flashlight;
    private bool isFlashlightOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;

        if (isFlashlightOn)
        {
            flashlight = Instantiate(flashlightPrefab, transform);
            flashlight.transform.localPosition = Vector3.zero;
            flashlight.transform.localRotation = Quaternion.identity;
        }
        else
        {
            if (flashlight != null)
            {
                Destroy(flashlight.gameObject);
            }
        }
    }
}
