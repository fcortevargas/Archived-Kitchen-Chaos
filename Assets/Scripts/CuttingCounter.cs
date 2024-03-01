using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // Cutting counter has no kitchen object
        {
            if (player.HasKitchenObject()) // Player has a kitchen object
            {
                // Place the kitchen object on the cutting counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        { // Clear counter has a kitchen object
            if (!player.HasKitchenObject()) // Player has no kitchen object
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate()
    {
        if (HasKitchenObject())
        {
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, this);
        }
    }
}
