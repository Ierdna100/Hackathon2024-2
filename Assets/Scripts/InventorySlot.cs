using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject shownObject;

    public void OnPickedUpItem()
    {
        // Mon dieu qu'on a pas de temps
        shownObject.SetActive(true);
    }
}
