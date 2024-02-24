using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLM_InteractionResponse
{
    public Choice[] choices;
    public int created;
    public string id;
    public string model;
    // public string object;
    public Usage usage;

    public string ToString()
    {
        string builder = "Choices: " + choices.Length + "\n";
        builder += "created: " + created + "\n";
        builder += "id: " + id + "\n";
        builder += "model: " + model + "\n";

        return builder;
    }
}
