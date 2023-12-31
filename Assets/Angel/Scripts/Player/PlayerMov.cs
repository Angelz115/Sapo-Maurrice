using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] float speed;
    private float moveInput;
    private Rigidbody2D rb;

    private bool facingRightn = true;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (moveInput != 0)
        {
            anim.SetBool("Moverse", true);

        }
        else
        {
            anim.SetBool("Moverse", false);
        }
        if (facingRightn == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRightn == true && moveInput < 0) 
        { 
            flip();
        }
    }

    private void flip() 
    {
        facingRightn = !facingRightn;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    public void Parar()
    {
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("Moverse", false);
    }
}
