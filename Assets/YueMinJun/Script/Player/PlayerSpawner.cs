using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] float respawnTimer = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        CharacterDeath.death += Respawn;
        GameHandler.reset += Reset;
    }

    private void Update()
    {
        Debug.Log(Character.Instance);
    }

    private void Respawn(object sender, System.EventArgs e)
    {
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTimer);
        Character.Instance.gameObject.SetActive(true);
        Character.Instance.gameObject.transform.position = transform.position;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        Character.Instance.collision.enabled = false;

        for (int x = 0; x < 10; x++)
        {
            yield return new WaitForSeconds(0.1f);
            Character.Instance.sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            Character.Instance.sprite.enabled = true;
        }

        Character.Instance.collision.enabled = true;
    }

    private void Reset(object sender, System.EventArgs e)
    {
        CharacterDeath.death -= Respawn;
        GameHandler.reset -= Reset;
    }
}
