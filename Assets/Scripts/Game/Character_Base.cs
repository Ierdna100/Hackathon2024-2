using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    public string genericPrompt;

    public virtual string GetLLMPrompt()
    {
        return genericPrompt;
    }
}
