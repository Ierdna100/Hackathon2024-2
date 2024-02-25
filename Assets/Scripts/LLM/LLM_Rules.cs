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
    public GlobalVariables globalVariables = new GlobalVariables();

    private void Start()
    {
        instance = this;
    }
}
