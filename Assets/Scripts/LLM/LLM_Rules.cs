using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLM_Rules : MonoBehaviour
{
    public class GlobalVariables
    {
        public bool newspaperPickedUp = false;
        public bool cardPickedUp = false;
    }

    public static LLM_Rules instance;

    public string rules;
    public GlobalVariables globalVariables;

    private void Start()
    {
        instance = this;
    }

    public List<LLM_Interactable.LLM_Message> GetGameRulesAsMessages()
    {
        var messages = new List<LLM_Interactable.LLM_Message>();

        messages.Add(new LLM_Interactable.LLM_Message("Variables globales", globalVariables.newspaperPickedUp ? "Le jouer a récupéré le journal" : "Le joueur n'a pas récupéré le journal"));
        messages.Add(new LLM_Interactable.LLM_Message("Variables globales", globalVariables.cardPickedUp ? "Le jouer a récupéré la carte OPUS" : "Le joueur n'a pas récupéré la carte OPUS"));

        return messages;
    }
}
