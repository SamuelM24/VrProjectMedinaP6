using UnityEngine;
using UnityEngine.UI;

public class ObjectRotation : MonoBehaviour
{
    public Slider rotationSlider;
    public float rotationSpeed = 90f;
    public GameObject prefab;

    private void Update()
    {
        // Get the slider value
        float rotationValue = rotationSlider.value;

        // Calculate the target rotation based on slider value
        float targetRotation = rotationValue * 180f;

        // Rotate both the pedestal and prefab smoothly
        RotateObjects(targetRotation);
    }

    private void RotateObjects(float targetRotation)
    {
        // Calculate rotation based on speed and time
        float step = rotationSpeed * Time.deltaTime;

        // Smoothly interpolate the rotation using Quaternion.Lerp
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, targetRotation, 0f), step);

        // Check if prefab is assigned before rotating
        if (prefab != null)
        {
            prefab.transform.rotation = Quaternion.Lerp(prefab.transform.rotation, Quaternion.Euler(0f, targetRotation, 0f), step);
        }
    }

    // Public method to be used in the Slider's On Value Changed event
    public void OnSliderValueChanged()
    {
        // Update the rotation based on the slider value
        float rotationValue = rotationSlider.value;
        float targetRotation = rotationValue * 180f;
        RotateObjects(targetRotation);
    }

    // Public method to set the prefab instance
    public void SetPrefabInstance(GameObject prefabInstance)
    {
        prefab = prefabInstance;
    }
}
