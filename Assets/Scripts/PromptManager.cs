using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public static PromptManager instance;

    public GameObject inputPrompt;
    public ResponseUI responseUI;
    public GameObject GO_ResponseUI;
    public GameObject player;

    public string playerText;

    void Awake()
    {
        instance = this;
        InputClose();
        ResponseClose();
    }

    public void InputClose()
    {
        inputPrompt.SetActive(false);
    }

    public void InputOpen()
    {
        inputPrompt.SetActive(true);
    }

    public void ResponseClose()
    {
        GO_ResponseUI.SetActive(false);
    }

    public void ResponseOpen()
    {
        GO_ResponseUI.SetActive(true);
        LLM_Manager.instance.AskLLM(new LLM_Message("Joueur", playerText), NPCResponseBoxManager.instance.characterData, NPCResponseBoxManager.instance.currentLLM.previousMessages);
    }

    public void OnUpdateText(string str)
    {
        playerText = str;
    }
}
