using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Character : NetworkBehaviour
{
    public static Character Instance { get; private set; }

    public SpriteRenderer sprite;
    public CircleCollider2D collision;

    Vector3 spawnPos;
    Rigidbody2D rb;

    private void Awake()
    {
        //if (Instance != null) return;
        if (!isOwned) return;

        if (Instance != null)
        {
            Debug.Log("Error");
        }
        Instance = this;
    }

    private void Start()
    {
        spawnPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
            Dead();
    }

    [Client]
    void Dead()
    {
        sprite.enabled = false;
        collision.enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        StartCoroutine(RespawnPlayer());
    }
    private void Respawn(object sender, System.EventArgs e)
    {
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        sprite.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 2.4f;
        gameObject.transform.position = spawnPos;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        collision.enabled = false;

        for (int x = 0; x < 10; x++)
        {
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
        }

        collision.enabled = true;
        
    }


}
