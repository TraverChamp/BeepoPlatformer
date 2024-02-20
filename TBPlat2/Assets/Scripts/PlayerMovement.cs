using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private float jumpForce = 800f;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D _rb;
    private float _xMoveInput;
    private bool shouldJump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void Update()
    {
        _xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }
    }
    private void FixedUpdate()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        _rb.velocity = new Vector2(_xMoveInput, _rb.velocity.y);
        bool isGrounded = col != null;
        if (shouldJump)
        {
            if (isGrounded)
            {
                _rb.AddForce(Vector2.up * jumpForce);
                shouldJump = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null, true);
        }
    }
}
