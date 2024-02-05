using UnityEngine;
using System.Collections.Generic;

public class ButtonHandler : MonoBehaviour
{
    public TrailDuplicator trailDuplicator;
    private List<Vector3> trailPoints = new List<Vector3>();
    public Transform spawnPoint; // Reference to the spawn point

    public void OnDrawButtonClicked()
    {
        // Manually capture or obtain the trail points as needed
        // For simplicity, let's say you have a predefined set of points
        trailPoints.Add(new Vector3(1f, 2f, 0f));
        trailPoints.Add(new Vector3(2f, 3f, 0f));
        trailPoints.Add(new Vector3(3f, 4f, 0f));

        // Call the DuplicateTrail method with the captured trail points and the spawn point position
        trailDuplicator.DuplicateTrail(trailPoints, spawnPoint.position);
    }
}
