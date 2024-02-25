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
    public GameObject inputPrompt;
    public ResponseUI responseUI;
    public GameObject GO_ResponseUI;
    public GameObject player;

    public Character characterData;
    public LLM_Interactable llm;

    public string NPCName;

    public string playerText;

    void Awake()
    {
        interactText.SetActive(false);
        InputClose();
        ResponseClose();
    }

    void Update()
    {
        if(interactText.activeInHierarchy == true && Input.GetKey(KeyCode.E))
        {
            inputPrompt.SetActive(true);
            NPCResponseBoxManager.instance.SetSpeakingCharacter(NPCName);
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

    public void InputClose()
    {
        inputPrompt.SetActive(false);
    }

    public void InputOpen()
    {
        playerText = "";
        inputPrompt.SetActive(true);
    }

    public void ResponseClose()
    {
        GO_ResponseUI.SetActive(false);
    }

    public void ResponseOpen()
    {
        GO_ResponseUI.SetActive(true);
        NPCResponseBoxManager.instance.currentLLM.AskLLM(new LLM_Interactable.LLM_Message("Joueur", playerText), characterData);
    }

    public void OnUpdateText(string str)
    {
        playerText = str;
    }
}
