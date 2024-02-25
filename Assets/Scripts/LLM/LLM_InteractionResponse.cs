using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLM_InteractionResponse
{
    public Choice[] choices;
    public int created;
    public string id;
    public string model;
    public Usage usage;
}
