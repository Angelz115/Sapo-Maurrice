using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telentranportar : MonoBehaviour
{
    public GameObject irA;
    public int id;
    public bool cooldown;
    public float timer, maxTime;

    private void Update()
    {
        if (cooldown)
            timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            cooldown = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            irA.GetComponent<CircleCollider2D>().enabled = true;
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (id == 1)
        {
            collision.transform.position = new Vector3(irA.transform.position.x,irA.transform.position.y,0);
        }
        else
        {
            collision.transform.position = new Vector3(irA.transform.position.x, irA.transform.position.y, 0);
        }
        irA.GetComponent<CircleCollider2D>().enabled = false;
        irA.GetComponent<Telentranportar>().cooldown = true;
        cooldown = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
