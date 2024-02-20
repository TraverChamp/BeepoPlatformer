using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipscript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight && rb.velocity.x < -0.1)
        {
            flip();
        }
        else if (!facingRight && rb.velocity.x > 0.1)
        {
            flip();
        }
    }
    private void flip()
    {
        facingRight =  !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
