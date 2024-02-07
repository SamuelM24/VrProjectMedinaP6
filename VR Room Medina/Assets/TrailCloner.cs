using UnityEngine;

public class TrailCloner : MonoBehaviour
{
    public GameObject spawnPoint; // Assign the spawn point GameObject in the Inspector

    public void CloneTrail()
    {
        // Find the trail object in the scene
        GameObject trailToClone = GameObject.Find("Trail(Clone)");

        if (trailToClone == null)
        {
            Debug.LogError("Trail to clone not found in the scene!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point not assigned!");
            return;
        }

        // Instantiate a copy of the trail object
        GameObject newTrail = Instantiate(trailToClone);

        // Set the position of the new trail to the spawn point position
        newTrail.transform.position = spawnPoint.transform.position;
    }
}
