using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerInteract;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // Container counter has no kitchen object
        {
            if (!player.HasKitchenObject()) // Player has no kitchen object
            {
                // Instantiate the kitchen object and assign the parent to the player
                KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

                // Event to trigger the animation in the visual logic
                OnPlayerInteract?.Invoke(this, EventArgs.Empty);
            }
            else // Player has a kitchen object
            {
                // Place the kitchen object on the container counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else // Container counter has a kitchen object
        {
            if (!player.HasKitchenObject())
            {
                // Place the kitchen object on the player
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
