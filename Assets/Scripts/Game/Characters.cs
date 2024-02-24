using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public bool canChage;

    public string context;
    LLM_Interactable.LLM_Message[] previousPrompts;
    public string actions;
}
