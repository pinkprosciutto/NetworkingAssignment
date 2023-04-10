using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PipeSpawner : NetworkBehaviour
{
    [SerializeField] float spawnTime = 1f;
    [SyncVar] float timer = 0;
    [SerializeField] GameObject pipePrefabs;
    [SerializeField] float spawnHeight = 1f;
    [SyncVar] Vector3 spawnPosition;
   

    // Update is called once per frame
    void Update()
    {
        //if (!isOwned) return;
        SpawnPipe();
    }

    [ServerCallback]
    private void SpawnPipe()
    {
        if (timer > spawnTime)
        {
            GameObject pipe = Instantiate(pipePrefabs);
            spawnPosition = transform.position + new Vector3(0, Random.Range(-spawnHeight, spawnHeight), 0);
            pipe.transform.position = spawnPosition;
            NetworkServer.Spawn(pipe);

            Destroy(pipe, 15);
            timer = 0;
            return;
        }

        timer += Time.deltaTime;
    }
}
