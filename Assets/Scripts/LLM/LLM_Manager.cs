using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class LLM_Manager : MonoBehaviour
{
    public static LLM_Manager instance;
    public static string URL = "http://blg21.iro.umontreal.ca:8080";
    // public static string URL = "http://localhost:8080";
    public static string APIEndpoint = "/v1/chat/completions";

    public LLM_InteractionResponse lastResponse;

    private void Awake()
    {
        instance = this;
    }

    public void AskLLM(LLM_Message message, Character_Base characterData, List<LLM_Message> previousMessages, bool setup = false)
    {
        lastResponse = null;
        StartCoroutine(GetLLMResponse(message, characterData, previousMessages, setup));
    }

    IEnumerator GetLLMResponse(LLM_Message message, Character_Base characterData, List<LLM_Message> previousMessages, bool setup)
    {
        var data = new LLM_Data();

        if (!setup)
        {
            data.messages.Add(LLM_Rules.instance.rulesCache);
        }
        data.messages.Add(message);

        // Prevent server crashes
        if (data.messages.Count == 0)
        {
            data.messages.Add(new LLM_Message("ERREUR", ""));
            Debug.LogError("Message count was 0! This is not supposed happen! A filler message was added to prevent server crash.");
        }
        // End of going around server code

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

        if (setup)
        {
            LLM_Rules.instance.rulesCache = lastResponse.choices[0].message;
        }

        if (previousMessages == null)
        {
            yield break;
        }

        foreach (LLM_Choice choice in lastResponse.choices)
        {
            previousMessages.Add(new LLM_Message(choice.message.role, choice.message.content));
        }
    }
}
