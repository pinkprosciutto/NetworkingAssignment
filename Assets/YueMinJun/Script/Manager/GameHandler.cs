using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] float gameTimer = 3f;
    float timer = 0;

    public static event EventHandler reset;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1;
        timer = gameTimer;
        CharacterDeath.death += OnDeath;
    }

    private void Update()
    {
        
    }
    private void OnDeath(object sender, System.EventArgs e)
    {
        Debug.Log("ded");
        //Character.Instance.gameObject.SetActive(false);
        
    }

  
}
