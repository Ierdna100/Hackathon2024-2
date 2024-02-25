using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage;

    public void OnItemPickup(Item item)
    {
        slotImage = item.image;
    }
}
