using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PosterBehaviour : MonoBehaviour
{
    public GameObject interactText;

    public GameObject posterText;

    public TMP_Text posterContents;

    // Update is called once per frame
    void Awake()
    {
        //AI Decides of the text
        //posterContents.text = "";

        interactText.SetActive(false);
        TextClose();
    }
    void Update()
    {
        if(interactText.activeInHierarchy == true && Input.GetKey(KeyCode.E))
        {
            TextOpen();
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

    public void TextOpen()
    {
        posterText.SetActive(true);
    }

    public void TextClose()
    {
        posterText.SetActive(false);
    }
}
