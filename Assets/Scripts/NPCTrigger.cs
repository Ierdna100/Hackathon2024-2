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
    public GameObject responseUI;
    public GameObject player;
<<<<<<< Updated upstream
    public TMP_InputField abc;
=======

>>>>>>> Stashed changes
    public string playerText;

    void Awake()
    {
        interactText.SetActive(false);
        InputClose();
        ResponseClose();
    }

    void Update()
    {
        if(interactText.activeInHierarchy == true && Input.GetKey(KeyCode.E))
        {
            inputPrompt.SetActive(true);
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
        //Send the request to the machine
<<<<<<< Updated upstream
        abc.text = "";
=======
        playerText = "";
>>>>>>> Stashed changes
    }

    public void InputOpen()
    {
        inputPrompt.SetActive(true);
    }

    public void ResponseClose()
    {
        responseUI.SetActive(false);
    }

    public void ResponseOpen()
    {
        responseUI.SetActive(true);
    }

    public void OnUpdateText(string str)
    {
        playerText = str;
    }
}
