using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine; 
using UnityEngine.UI;

public class NPCTrigger : MonoBehaviour
{
    public BoxCollider2D NPC_Collider;
    public GameObject interactText;

    public Character_Base characterData;
    public LLM_Interactable llm;

    public string NPCName;

    private void Awake()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        if(interactText.activeInHierarchy && Input.GetKey(KeyCode.E))
        {
            PromptManager.instance.InputOpen();
            NPCResponseBoxManager.instance.OnChangeTarget(NPCName, llm, characterData);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NPCResponseBoxManager.instance.currentLLM = llm;
        interactText.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        interactText.SetActive(false);
    }
}
