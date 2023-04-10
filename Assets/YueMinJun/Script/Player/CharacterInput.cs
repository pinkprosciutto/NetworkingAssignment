using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

public class CharacterInput : NetworkBehaviour
{
    public static event EventHandler SpacePressed;

    [Client]
    void Update()
    {
        if (!isOwned) return; 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SpacePressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
