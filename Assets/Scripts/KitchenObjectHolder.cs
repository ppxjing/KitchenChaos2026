using UnityEngine;
using UnityEngine.Serialization;

public class KitchenObjectHolder : MonoBehaviour
{
    [FormerlySerializedAs("topPoint")]
    [SerializeField] private Transform holdPoint;

    private KitchenObject kitchenObject;

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public bool IsKitchenObjectPresent()
    {
        return kitchenObject != null;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.SetParent(holdPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
    }

    public Transform GetTopPoint()
    {
        return holdPoint;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public void TransferKitchenObject(KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() != null && targetHolder.GetKitchenObject() == null)
        {
            KitchenObject sourceKitchenObject = sourceHolder.GetKitchenObject();
            sourceHolder.ClearKitchenObject();
            targetHolder.SetKitchenObject(sourceKitchenObject);
        }
        else
        {
            Debug.LogWarning("Transfer failed: Source holder has no kitchen object or target holder already has one.");
        }
    }
}
