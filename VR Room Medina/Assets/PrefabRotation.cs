using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PrefabRotation : MonoBehaviour
{
    private Slider rotationSlider;
    public float rotationSpeed = 90f;

    private void Start()
    {
        // Find the Slider component in the scene
        rotationSlider = FindObjectOfType<Slider>();

        if (rotationSlider == null)
        {
            UnityEngine.Debug.LogError("Slider not found in the scene.");
            return;
        }

        // Set up the slider's on value changed listener
        rotationSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        // Rotate the prefab based on the slider value
        float rotationAngle = value * 180f; // Assuming the slider values range from 0 to 1
        transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
    }
}
