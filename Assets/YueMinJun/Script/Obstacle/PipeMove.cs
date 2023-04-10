using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PipeMove : NetworkBehaviour
{
    [SerializeField] float speed = 5f;
    float moveSpeed = 0f;

    [SyncVar] Vector3 pipePosition;

    void Update()
    {
        //transform.position += Vector3.left * speed * Time.deltaTime;
        pipePosition += Vector3.left * speed * Time.deltaTime;
        transform.position = pipePosition;
        //transform.position += Vector3.left * speed * Time.deltaTime;
    }

    [Command]
    private void CmdMove()
    {
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
