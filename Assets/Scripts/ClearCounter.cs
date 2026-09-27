using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (GetKitchenObject() != null && player.GetKitchenObject() == null)
        {
            TransferKitchenObject(this, player);
        }
        else if (GetKitchenObject() == null && player.GetKitchenObject() != null)
        {
            TransferKitchenObject(player, this);
        }
    }
}
