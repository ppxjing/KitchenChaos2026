using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSo kitchenObjectPrefab;
    [SerializeField] private ContainerCounterVisual containerCounterVisual;


    public override void Interact(Player player)
    {
        if (player.IsKitchenObjectPresent())
        {
            return;
        }

        CreateKitchenObject(kitchenObjectPrefab.prefab);
        TransferKitchenObject(this, player);

        containerCounterVisual.PlayOpen();
    }
    private void CreateKitchenObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = Instantiate(
            kitchenObjectPrefab,
            GetTopPoint()).GetComponent<KitchenObject>();

        SetKitchenObject(kitchenObject);
    }

}