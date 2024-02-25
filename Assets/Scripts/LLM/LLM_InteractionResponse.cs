using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLM_InteractionResponse
{
    public LLM_Choice[] choices;
    public int created;
    public string id;
    public string model;
    public LLM_Usage usage;
}
