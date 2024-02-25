using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public InventorySlot[] slots;
    public string[] paths;
    public int indexJournal = 0;
    public int indexCard = 1;
    public int indexOPUS = 2;

    private void Awake()
    {
        instance = this;
        paths = new String["Assets/Sprites/Items/news.png", "Assets/Sprites/Items/flower.png", "Assets/Sprites/Items/Card1.png"];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
