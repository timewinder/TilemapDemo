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
    
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        bool currentlyGrounded = IsGrounded();
        if (currentlyGrounded && !previouslyGrounded) {
            bwheheheehorgouer.localScale = new Vector2(1.5f, 0.5f);
        }

        float walkMovement = Input.GetAxis("Horizontal");
        rigidbody.AddForce(Vector2.right * walkMovement * walkVelocity * Time.deltaTime, ForceMode2D.Impulse);
        transform.localEulerAngles = new Vector3(0, Mathf.Clamp(walkMovement * 180, -180, 0), 0);
        if (currentlyGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))) {
            rigidbody.velocity += Vector2.up * jumpVelocity;
            bwheheheehorgouer.localScale = new Vector2(0.2f, 2.5f);
        }

        previouslyGrounded = currentlyGrounded;
        bwheheheehorgouer.localScale = Vector2.Lerp(bwheheheehorgouer.localScale, Vector2.one, 0.15f);
    }
    
    public bool IsGrounded() {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.9f, 0.01f), 0, groundedMask);
    }
}
