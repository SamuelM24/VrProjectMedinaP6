using UnityEngine;

public class PedestalToggle : MonoBehaviour
{
    public GameObject pedestal;

    // Toggle the visibility of the pedestal
    public void TogglePedestal()
    {
        if (pedestal != null)
        {
            pedestal.SetActive(!pedestal.activeSelf);
        }
    }
}
