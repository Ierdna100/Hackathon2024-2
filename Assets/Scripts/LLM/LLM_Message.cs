using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLM_Message
{
    public string role;
    public string content;

    public LLM_Message(string role, string content)
    {
        this.role = role;
        this.content = content;
    }
}
