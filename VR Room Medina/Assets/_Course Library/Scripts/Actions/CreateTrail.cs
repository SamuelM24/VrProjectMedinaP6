using UnityEngine;

public class CreateTrail : MonoBehaviour
{
    public GameObject trailPrefab = null;

    private float width = 0.05f;
    private Color color = Color.white;

    private GameObject drawnTrail; // Variable to store the drawn trail

    public void StartTrail()
    {
        Debug.Log("StartTrail method called."); // Debug log to track method call
        if (!drawnTrail)
        {
            drawnTrail = Instantiate(trailPrefab, transform.position, transform.rotation, transform);
            ApplySettings(drawnTrail);
        }
    }

    private void ApplySettings(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = width;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }

    public void EndTrail()
    {
        Debug.Log("EndTrail method called."); // Debug log to track method call
        if (drawnTrail)
        {
            drawnTrail.transform.parent = null;
            drawnTrail = null;
        }
    }

    public void SetWidth(float value)
    {
        width = value;
    }

    public void SetColor(Color value)
    {
        color = value;
    }

    public GameObject GetDrawnTrail()
    {
        return drawnTrail;
    }

    public void SetDrawnTrail(GameObject trail)
    {
        drawnTrail = trail;
    }
}
