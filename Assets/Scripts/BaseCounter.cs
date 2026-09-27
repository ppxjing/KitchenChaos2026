using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectedCounterVisual;

    public virtual void Interact(Player player)
    {
    }
    public void SelectCounter()
    {
        selectedCounterVisual.SetActive(true);
    }

    public void CancelSelect()
    {
        selectedCounterVisual.SetActive(false);
    }



}
