using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkVelocity;
    public float jumpVelocity;
    public Transform bwheheheehorgouer;
    public Transform groundCheck;
    public LayerMask groundedMask;
    private Rigidbody2D rigidbody;
    private bool previouslyGrounded;
    // private bool flipped;
    
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        bool currentlyGrounded = IsGrounded();
        if (currentlyGrounded && !previouslyGrounded) {
            bwheheheehorgouer.localScale = new Vector2(1.5f, 0.5f);
        }

        float walkMovement = Input.GetAxis("Horizontal");
        rigidbody.velocity = Vector2.right * walkMovement * walkVelocity + Vector2.up * rigidbody.velocity.y;
        // transform.localEulerAngles = new Vector3(0, Mathf.Clamp(walkMovement * 180, -180, 0), 0);
        if (currentlyGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))) {
            rigidbody.velocity += Vector2.up * jumpVelocity;
            bwheheheehorgouer.localScale = new Vector2(0.2f, 1.75f);
        }

        if (walkMovement < 0) {
            // flipped = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if (walkMovement > 0) {
            // flipped = false;
            transform.localEulerAngles = Vector3.zero;
        }

        previouslyGrounded = currentlyGrounded;
        bwheheheehorgouer.localScale = Vector2.Lerp(bwheheheehorgouer.localScale, Vector2.one, 0.15f);
    }
    
    public bool IsGrounded() {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.9f, 0.1f), 0, groundedMask);
    }
}
