using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMovement : NetworkBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] float jumpForce = 5f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CharacterInput.SpacePressed += Jump;
        GameHandler.reset += Reset;
    }


    [Client]
    private void Jump(object sender, System.EventArgs e)
    {
        if (!isOwned) return;
        CmdJump();
    }
    
    [Command]
    private void CmdJump()
    {
        RpcJump();
    }

    [ClientRpc]
    private void RpcJump()
    {
        rigidbody.velocity = Vector2.up * jumpForce;
    }

    private void Reset(object sender, System.EventArgs e)
    {
        CharacterInput.SpacePressed -= Jump;
        GameHandler.reset -= Reset;
    }
}
