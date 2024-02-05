using UnityEngine;
using System.Collections.Generic;

public class TrailDrawer : MonoBehaviour
{
    private List<Vector3> trailPoints = new List<Vector3>();

    public List<Vector3> GetTrailPoints()
    {
        return new List<Vector3>(trailPoints);
    }

    // Other methods to clear the trail or finish the drawing can be added here

    void Update()
    {
        // Assuming you start drawing the trail when a button is pressed (e.g., left mouse button)
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            trailPoints.Add(mousePosition);
        }
    }
}
