using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class LLM_Interactable : MonoBehaviour
{
    // public static string URL = "http://blg21.iro.umontreal.ca:8080";
    public static string URL = "http://localhost:8080";
    public static string APIEndpoint = "/v1/chat/completions";

    public LLM_InteractionResponse lastResponse;

    private void Awake()
    {
        lastResponse = null;
    }

    public void AskLLM()
    {
        lastResponse = null;
        StartCoroutine(GetLLMResponse());
    }

    IEnumerator GetLLMResponse()
    {
        var data = new LLM_Data();
        data.messages.Add(new LLM_Message("controlleurSTM", "allo"));

        // Prevent server crashes
        if (data.messages.Count == 0)
        {
            data.messages.Add(new LLM_Message("user", ""));
            Debug.LogError("Message count was 0!");
        }

        string dataAsJson = JsonConvert.SerializeObject(data);

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
