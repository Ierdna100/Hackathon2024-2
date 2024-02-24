using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool playerFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(float move)
    {
        if(move > 0 && !playerFacingRight)
        {
            Flip();
        }
        else if(move < 0 && playerFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector2 scale = transform.localScale;

        scale.
    }
}
