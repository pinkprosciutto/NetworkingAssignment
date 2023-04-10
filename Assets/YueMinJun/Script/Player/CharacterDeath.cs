using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

public class CharacterDeath : NetworkBehaviour
{
    public static event EventHandler death;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            death?.Invoke(this, EventArgs.Empty);

        }
    }
}
