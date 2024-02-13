using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YourNamespace
{
    public class TeleportationAnchorCanvasActivator : MonoBehaviour
    {
        [SerializeField]
        Canvas canvasToActivate;

        private void Start()
        {
            // Ensure canvas is initially deactivated
            canvasToActivate.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GetComponent<TeleportationAnchor>().selectEntered.AddListener(OnTeleportSelectEntered);
        }

        private void OnDisable()
        {
            GetComponent<TeleportationAnchor>().selectEntered.RemoveListener(OnTeleportSelectEntered);
        }

        private void OnTeleportSelectEntered(SelectEnterEventArgs args)
        {
            // Activate/popup canvas when teleportation anchor is selected
            canvasToActivate.gameObject.SetActive(true);
        }
    }
}
