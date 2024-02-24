using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class NPCTrigger : MonoBehaviour
{
    public BoxCollider2D NPC_Collider;
    public TextMeshProUGUI interactText;

    void Awake()
    {
        interactText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Collider");
        interactText.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited Collider");
        interactText.enabled = false;
    }
}
