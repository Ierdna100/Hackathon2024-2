using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class LLM_Interactable : MonoBehaviour
{
    public List<LLM_Message> previousMessages = new List<LLM_Message>();

    private void Awake()
    {
        LLM_Manager.instance.lastResponse = null;
    }

    public void ResetMessages()
    {
        previousMessages = new List<LLM_Message>();
    }
}
