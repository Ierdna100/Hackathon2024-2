using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class NPCTrigger : MonoBehaviour
{
    public BoxCollider2D NPC_Collider;
    public GameObject interactText;
    public GameObject inputPrompt;
    public TMP_Text playerText;

    void Awake()
    {
        interactText.SetActive(false);
        InputClose();
        playerText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if(interactText.activeInHierarchy == true && Input.GetKey(KeyCode.E))
        {
            inputPrompt.SetActive(true);
            Debug.Log(playerText.text);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Collider");
        interactText.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited Collider");
        interactText.SetActive(false);
    }

    public void InputClose()
    {
        inputPrompt.SetActive(false);
    }
}
