using UnityEngine;

public class DynamicPrefabDuplicator : MonoBehaviour
{
    public GameObject prefabToDuplicate;
    public GameObject pedestalObject;
    public float abovePedestalHeight = 0.5f;
    public float shrinkFactor = 0.5f;

    public void DuplicateAndShrinkPrefab()
    {
        // Ensure that prefabToDuplicate and pedestalObject are not null
        if (prefabToDuplicate == null || pedestalObject == null)
        {
            Debug.LogError("PrefabToDuplicate or PedestalObject is not set!");
            return;
        }

        // Get the position of the pedestal
        Vector3 pedestalPosition = pedestalObject.transform.position;

        // Instantiate the prefab at an offset above the pedestal
        GameObject duplicatedPrefab = Instantiate(prefabToDuplicate, pedestalPosition + Vector3.up * abovePedestalHeight, Quaternion.identity);

        // Shrink the duplicated prefab
        duplicatedPrefab.transform.localScale *= shrinkFactor;

        // Find the Trail Renderer on the original prefab and its clone
        TrailRenderer originalTrail = prefabToDuplicate.GetComponentInChildren<TrailRenderer>();
        TrailRenderer clonedTrail = duplicatedPrefab.GetComponentInChildren<TrailRenderer>();

        // Check if both the original and cloned trails exist
        if (originalTrail != null && clonedTrail != null)
        {
            // Copy relevant settings from the original Trail Renderer to the cloned one
            clonedTrail.time = originalTrail.time;
            clonedTrail.startWidth = originalTrail.startWidth;
            clonedTrail.endWidth = originalTrail.endWidth;
            // Add other settings as needed
        }
    }
}
