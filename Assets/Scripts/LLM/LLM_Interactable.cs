using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class LLM_Interactable : MonoBehaviour
{
    public static string URL = "http://blg21.iro.umontreal.ca:8080";
    // public static string URL = "http://localhost:8080";
    public static string APIEndpoint = "/v1/chat/completions";

    public List<LLM_Message> previousMessages = new List<LLM_Message>();

    public LLM_InteractionResponse lastResponse;

    private void Awake()
    {
        lastResponse = null;
    }

    public void ResetMessages()
    {
        previousMessages = new List<LLM_Message>();
    }

    public void AskLLM(LLM_Message message, Character_Base characterData)
    {
        lastResponse = null;
        StartCoroutine(GetLLMResponse(message, characterData));
    }

    IEnumerator GetLLMResponse(LLM_Message message, Character_Base characterData)
    {
        var data = new LLM_Data();
        data.messages.Add(new LLM_Message("Règlement", LLM_Rules.instance.rules));
        
        data.messages.Add(message);

        // Prevent server crashes
        if (data.messages.Count == 0)
        {
            data.messages.Add(new LLM_Message("ERREUR", ""));
            Debug.LogError("Message count was 0! This is not supposed happen! A filler message was added to prevent server crash.");
        }
        // End of going around terrible server code

        string dataAsJson = JsonConvert.SerializeObject(data);
        Debug.Log(dataAsJson);

        UnityWebRequest webRequest = UnityWebRequest.Post(URL + APIEndpoint, dataAsJson, "application/json");
        webRequest.SetRequestHeader("Authorization", "Bearer no-key");

        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                break;
        }

        lastResponse = JsonConvert.DeserializeObject<LLM_InteractionResponse>(webRequest.downloadHandler.text);

        foreach (Choice choice in lastResponse.choices)
        {
            previousMessages.Add(new LLM_Message(choice.message.role, choice.message.content));
        }
    }

    public class LLM_Data
    {
        public string model = "LLaMA_CPP";
        public List<LLM_Message> messages = new List<LLM_Message>();
    }

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
}
