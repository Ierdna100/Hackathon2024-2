using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLM_Rules : MonoBehaviour
{
    public class GlobalVariables
    {
        public bool newspaperPickedUp = false;
        public bool askingCardPickedUp = false;
        public bool ticketPickedUp = false;
    }
    
    public static LLM_Rules instance;

    public string rules;
    public LLM_Message rulesCache;

    public GlobalVariables globalVariables = new();

    private void Start()
    {
        instance = this;
        // LLM_Manager.instance.AskLLM(new LLM_Message("Jeu", rules), null, null, true);
    }
}
