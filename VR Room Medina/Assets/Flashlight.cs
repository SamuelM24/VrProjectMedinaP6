using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    private bool isLightOn = false;

    private void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        if (flashlight == null)
        {
            Debug.LogError("No spotlight found as a child of the flashlight object.");
            return;
        }

        // Ensure the light starts off
        flashlight.enabled = false;
    }

    public void Flip()
    {
        isLightOn = !isLightOn;
        flashlight.enabled = isLightOn;
    }
}
