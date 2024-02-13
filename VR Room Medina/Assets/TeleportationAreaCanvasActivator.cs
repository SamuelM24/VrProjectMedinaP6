using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YourNamespace
{
    public class TeleportationAreaCanvasActivator : MonoBehaviour
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
            GetComponent<TeleportationArea>().selectEntered.AddListener(OnTeleportSelectEntered);
        }

        private void OnDisable()
        {
            GetComponent<TeleportationArea>().selectEntered.RemoveListener(OnTeleportSelectEntered);
        }

        private void OnTeleportSelectEntered(SelectEnterEventArgs args)
        {
            // Activate/popup canvas when teleportation area is selected
            canvasToActivate.gameObject.SetActive(true);
        }
    }
}
