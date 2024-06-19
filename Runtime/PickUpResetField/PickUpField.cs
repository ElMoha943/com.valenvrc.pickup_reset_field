using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

public class PickUpField : UdonSharpBehaviour
{
    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            //Get the pickup on the players right hand
            VRC_Pickup pickup = Networking.LocalPlayer.GetPickupInHand(VRC_Pickup.PickupHand.Right);
            if (pickup != null){
                //Drop the pickup
                pickup.Drop();
                //Get vrc object sync
                VRCObjectSync objSync = pickup.gameObject.GetComponent<VRCObjectSync>();
                //Respawn the pickup
                objSync.Respawn();
            }
            //Get the pickup on the players left hand
            pickup = Networking.LocalPlayer.GetPickupInHand(VRC_Pickup.PickupHand.Left);
            if (pickup != null){
                //Drop the pickup
                pickup.GetComponent<VRC_Pickup>().Drop();
                //Get vrc object sync
                VRCObjectSync objSync = pickup.GetComponent<VRCObjectSync>();
                //Respawn the pickup
                objSync.Respawn();
            }
        }
    }
}
