using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RugTeleport : TeleportationAnchor
{
    public Canvas tooltipCanvas;

    private bool tooltipDisplayed = false;

    protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
    {
        bool baseResult = base.GenerateTeleportRequest(interactor, raycastHit, ref teleportRequest);

        // Check if the base teleport request was successful and the tooltip has not been displayed yet
        if (baseResult && !tooltipDisplayed)
        {
            // Show the canvas UI
            tooltipCanvas.gameObject.SetActive(true);
            tooltipDisplayed = true;
        }

        return baseResult;
    }
}
