using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // Clear counter has no kitchen object
        {
            if (player.HasKitchenObject()) // Player has a kitchen object
            {
                // Place the kitchen object on the clear counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        { // Clear counter has a kitchen object
            if (!player.HasKitchenObject()) // Player has a kitchen object
            {
                // Place the kitchen object on the player
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
