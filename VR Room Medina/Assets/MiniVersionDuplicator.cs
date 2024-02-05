using UnityEngine;

public class MiniVersionDuplicator : MonoBehaviour
{
    public GameObject miniVersionPrefab;

    public void DuplicateMiniVersion()
    {
        GameObject duplicatedMiniVersion = Instantiate(miniVersionPrefab);

        // If the mini version has a Trail Renderer, you can set its settings similarly to what we did above
        TrailRenderer miniVersionTrailRenderer = duplicatedMiniVersion.GetComponent<TrailRenderer>();

        if (miniVersionTrailRenderer != null)
        {
            // Set Trail Renderer settings for the mini version as needed
        }
    }
}
