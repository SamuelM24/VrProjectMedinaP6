using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SliderRotation : MonoBehaviour
{
    public Slider slider; // Reference to the slider in the Unity Editor
    public Transform rotatingObject; // Reference to the object you want to rotate

    private Quaternion initialRotation;
    private bool isRotating = false;
    private float rotationSpeed = 90f; // Adjust this value to control the rotation speed

    void Start()
    {
        initialRotation = rotatingObject.rotation;
        slider.onValueChanged.AddListener(RotateObject);
    }

    void RotateObject(float value)
    {
        if (!isRotating)
        {
            isRotating = true;
            StartCoroutine(RotateCoroutine());
        }
    }

    IEnumerator RotateCoroutine()
    {
        float targetAngle = initialRotation.eulerAngles.y + 180f;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

        while (Quaternion.Angle(rotatingObject.rotation, targetRotation) > 0.1f)
        {
            rotatingObject.rotation = Quaternion.RotateTowards(rotatingObject.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        rotatingObject.rotation = targetRotation;
        isRotating = false;
    }
}
