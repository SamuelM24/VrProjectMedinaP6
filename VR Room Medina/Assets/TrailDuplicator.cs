// TrailDuplicator.cs
using UnityEngine;
using System.Collections.Generic;

public class TrailDuplicator : MonoBehaviour
{
    public TrailRenderer trailPrefab; // This should be a prefab with TrailRenderer component
    public float pointSpacing = 0.1f; // Adjust this value as needed

    // Call this method when you want to duplicate the trail at a new location
    public void DuplicateTrail(List<Vector3> trailPoints, Vector3 newPosition)
    {
        GameObject trailObject = new GameObject("DuplicatedTrail");
        TrailRenderer newTrail = trailObject.AddComponent<TrailRenderer>();

        // Set the material of the duplicated trail to match the original trail
        if (trailPrefab != null && trailPrefab.sharedMaterial != null)
        {
            // Set the material using sharedMaterial
            newTrail.material = trailPrefab.sharedMaterial;

            // Set other properties of the TrailRenderer as needed
            newTrail.time = trailPrefab.time;
            newTrail.startWidth = trailPrefab.startWidth;
            newTrail.endWidth = trailPrefab.endWidth;

            // Set the new position
            trailObject.transform.position = newPosition;

            // Set the trail points
            SetTrailPoints(newTrail, trailPoints);

            // Clean up duplicated trail after a certain period
            StartCoroutine(DestroyDuplicatedTrail(trailObject, newTrail.time));
        }
        else
        {
            UnityEngine.Debug.LogError("Trail Prefab or its sharedMaterial not assigned in the inspector!");
        }
    }

    // Helper method to set the trail points
    private void SetTrailPoints(TrailRenderer trailRenderer, List<Vector3> trailPoints)
    {
        // Set the positions using SetPositions
        trailRenderer.SetPositions(trailPoints.ToArray());
    }

    // Helper method to destroy the duplicated trail after a certain delay
    private System.Collections.IEnumerator DestroyDuplicatedTrail(GameObject trailObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(trailObject);
    }
}
