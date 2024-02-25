using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCResponseBoxManager : MonoBehaviour
{
    public static NPCResponseBoxManager instance;
    public TMP_Text header;
    public LLM_Interactable currentLLM;
    public Character characterData;

    private void Start()
    {
        instance = this;
    }

    public void OnChangeTarget(string name, LLM_Interactable llm, Character characterData)
    {
        header.text = name;
        currentLLM = llm;
        this.characterData = characterData;
    }
}
