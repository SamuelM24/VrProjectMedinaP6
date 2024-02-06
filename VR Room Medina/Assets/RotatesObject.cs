using UnityEngine;
using UnityEngine.UI;

public class RotatesObject : MonoBehaviour
{
    public Slider rotationSlider; // Reference to the slider for controlling rotation
    public GameObject objectToRotate; // Reference to the object you want to rotate

    void Update()
    {
        // Check if the slider is not null and the object to rotate is not null
        if (rotationSlider != null && objectToRotate != null)
        {
            // Calculate the target rotation based on the slider value
            float targetRotation = rotationSlider.value * 180f;

            // Rotate the object gradually towards the target rotation
            objectToRotate.transform.rotation = Quaternion.Lerp(objectToRotate.transform.rotation, Quaternion.Euler(0f, targetRotation, 0f), Time.deltaTime);
        }
    }
}
