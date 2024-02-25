using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Gertrude : Character_Base
{
    public string promptIfAskingCardShown = "";

    public override string GetLLMPrompt()
    {
        if (LLM_Rules.instance.globalVariables.askingCardPickedUp)
        {
            return genericPrompt + promptIfAskingCardShown;
        }

        return base.GetLLMPrompt();
    }
}
