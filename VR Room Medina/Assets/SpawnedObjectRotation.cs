
using UnityEngine;
using UnityEngine.UI;

public class SpawnedObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private Slider rotationSlider;
    private float totalRotation = 0f;
    private bool isRotating = false;

    void Start()
    {
        // Find the Slider prefab with the name "Slider" in the scene
        GameObject sliderObject = GameObject.Find("Slider");

        if (sliderObject != null)
        {
            // Instantiate the Slider prefab
            rotationSlider = Instantiate(sliderObject).GetComponent<Slider>();

            if (rotationSlider != null)
            {
                // Set up the slider's OnValueChanged event
                rotationSlider.onValueChanged.AddListener(HandleSliderValueChanged);
            }
            else
            {
                Debug.LogError("Slider component not found on the instantiated Slider prefab.");
            }
        }
        else
        {
            Debug.LogError("Slider prefab with the name 'Slider' not found. Make sure it exists in the scene.");
        }
    }

    void Update()
    {
        if (isRotating)
        {
            // Get the slider value and apply rotation
            float rotationValue = rotationSlider.value;
            RotateObject(rotationValue);
        }
    }

    void RotateObject(float rotationValue)
    {
        // Calculate rotation based on slider value and speed
        float rotationAmount = rotationValue * rotationSpeed * Time.deltaTime;

        // Update the total rotation
        totalRotation += Mathf.Abs(rotationAmount);

        // Rotate the object around its up axis
        transform.Rotate(Vector3.up, rotationAmount);

        // Check if we have rotated 180 degrees, then stop rotating
        if (totalRotation >= 180f)
        {
            totalRotation = 180f; // Clamp the total rotation to 180 degrees
            isRotating = false;   // Stop rotating
            rotationSlider.interactable = false; // Disable slider interaction
        }
    }

    void HandleSliderValueChanged(float value)
    {
        isRotating = true; // Set the rotation flag when the slider is being manipulated
    }
}
