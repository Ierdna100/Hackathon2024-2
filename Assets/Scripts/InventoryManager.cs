using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public InventorySlot[] slots;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        var rules = LLM_Rules.instance.globalVariables;

        // Code terrible qui va me faire virer de tous mes emplois futurs
        if (rules.askingCardPickedUp)
        {
            slots[0].OnPickedUpItem();
        }

        if (rules.newspaperPickedUp)
        {
            slots[1].OnPickedUpItem();
        }

        if (rules.ticketPickedUp)
        {
            slots[2].OnPickedUpItem();
        }
    }
}
