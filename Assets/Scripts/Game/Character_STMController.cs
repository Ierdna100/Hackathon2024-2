using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_STMController : Character_Base
{
    public string promptIfNewspaperAcquired = "";

    public override string GetLLMPrompt()
    {
        if (LLM_Rules.instance.globalVariables.newspaperPickedUp)
        {
            return genericPrompt + promptIfNewspaperAcquired;
        }

        return genericPrompt;
    }
}
