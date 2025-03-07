using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    //variables for ladder script
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody rb;

    void Update()
    {
        //checks vertical axis
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        //checks if player is climbing ladder
        if (isClimbing)
        {          
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //checks if player is on ladder
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}

