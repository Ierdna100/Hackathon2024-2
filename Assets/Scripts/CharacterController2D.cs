using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public bool playerFacingRight = true;
	[SerializeField]
    public Rigidbody2D playerRigidBody;

	[SerializeField]
	private Vector2 velocity;

	public float speed = 5.0f;

    public void Move(float move)
    {	
        if (move > 0 && !playerFacingRight)
        {
            Flip();
        }
        else if (move < 0 && playerFacingRight)
        {
            Flip();
        }

		velocity = new Vector2(1.75f, 1.1f);

        Vector2 movement = new Vector2(move * speed, 0f);
		playerRigidBody.MovePosition(playerRigidBody.position + movement);
    }

    void Flip()
    {
        playerFacingRight = !playerFacingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

