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
        newTrail.sharedMaterial = trailPrefab.sharedMaterial;

        // Set other properties of the TrailRenderer as needed
        newTrail.time = trailPrefab.time;
        newTrail.startWidth = trailPrefab.startWidth;
        newTrail.endWidth = trailPrefab.endWidth;

        // Set the new position
        trailObject.transform.position = newPosition;

        // Set the trail points
        SetTrailPoints(newTrail, trailPoints);
    }

    // Helper method to set the trail points
    private void SetTrailPoints(TrailRenderer trailRenderer, List<Vector3> trailPoints)
    {
        if (trailPoints.Count > 0)
        {
            // Create a list to store individual positions
            List<Vector3> individualPositions = new List<Vector3>();

            // Iterate through the points and add them to the list
            foreach (Vector3 point in trailPoints)
            {
                individualPositions.Add(point);
            }

            // Use the individualPositions list to set positions using SetPositions
            trailRenderer.SetPositions(individualPositions.ToArray());
        }
    }
}
