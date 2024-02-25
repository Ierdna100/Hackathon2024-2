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
        if (llm.lastResponse == null)
        {
            text.text = "...";
            return;
        }

        foreach (Choice choice in llm.lastResponse.choices)
        {
            Debug.Log("> " + choice.message.content);
        }

        text.text = llm.lastResponse.choices[0].message.content;
    }
}
