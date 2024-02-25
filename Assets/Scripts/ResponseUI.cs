using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseUI : MonoBehaviour
{
    public TMP_Text text;
    public LLM_Interactable llm;

    private void Update()
    {
        if (LLM_Manager.instance.lastResponse == null)
        {
            text.text = "...";
            return;
        }

        foreach (LLM_Choice choice in LLM_Manager.instance.lastResponse.choices)
        {
            Debug.Log("> " + choice.message.content);
        }

        text.text = LLM_Manager.instance.lastResponse.choices[0].message.content;
    }
}
