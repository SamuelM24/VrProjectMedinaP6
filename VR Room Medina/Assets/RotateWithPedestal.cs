using System.Diagnostics;
using UnityEngine;

public class RotateWithPedestal : MonoBehaviour
{
    // Reference to the pedestal's transform
    public Transform pedestalTransform;

    // Update is called once per frame
    void Update()
    {
        // Check if the pedestal transform is assigned
        if (pedestalTransform != null)
        {
            // Apply the same rotation as the pedestal
            transform.rotation = pedestalTransform.rotation;
        }
        else
        {
            // Log an error if the pedestal transform is not assigned
            UnityEngine.Debug.LogError("Pedestal Transform is not assigned to RotateWithPedestal script.");
        }
    }
}
