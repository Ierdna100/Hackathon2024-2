using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCResponseBoxManager : MonoBehaviour
{
    public static NPCResponseBoxManager instance;
    public TMP_Text header;
    public LLM_Interactable currentLLM;

    private void Start()
    {
        instance = this;
    }

    public void SetSpeakingCharacter(string name)
    {
        header.text = name;
    }

    public void SetLLM(LLM_Interactable llm)
    {
        currentLLM = llm;
    }
}
