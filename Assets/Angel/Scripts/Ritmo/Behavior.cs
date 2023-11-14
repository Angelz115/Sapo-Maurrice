using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    public Vector2 target;
    public Rigidbody2D rb;
    public float force;
    public Color thisColor;
    public int Tar;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = target - new Vector2(transform.position.x, transform.position.y);
        rb.AddForce(direction * force);
        thisColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tap"))
        {
            return;
        }
        if (Tar == collision.GetComponent<Tap>().tap)
        {
            Destroy(gameObject);
        }
    }
}
