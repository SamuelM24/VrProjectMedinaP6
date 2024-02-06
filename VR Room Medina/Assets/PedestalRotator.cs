using UnityEngine;
using UnityEngine.UI;

public class PedestalRotator : MonoBehaviour
{
    public Transform pedestalTransform;
    public Slider rotationSlider;

    void Start()
    {
        // Attach the method to the slider's valueChanged event
        rotationSlider.onValueChanged.AddListener(RotatePedestal);
    }

    // Function called when the slider value changes
    public void RotatePedestal(float angle)
    {
        // Rotate the pedestal around the Y-axis based on the slider value
        pedestalTransform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
