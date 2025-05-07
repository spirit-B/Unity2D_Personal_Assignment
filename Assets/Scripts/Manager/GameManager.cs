using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FlappyUIManager flappyUIManager;

    private int currentScore = 0;
    public static bool isRestart = false;

    public PlayerController _player { get; private set; }
    public IInputStrategy InputStrategy { get; private set; }

    public FlappyUIManager FlappyUIManaer { get { return flappyUIManager; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "FlappyScene")
        {
            flappyUIManager.UpdateScore(0);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            Time.timeScale = 1f;
            InputStrategy = new WASDStrategy();
        }
        else if (scene.name == "FlappyScene")
        {
            InputStrategy = new MouseStrategy();
            flappyUIManager = FindObjectOfType<FlappyUIManager>();
        }

        _player = FindObjectOfType<PlayerController>();
        if (_player != null)
            _player.Init(this);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        flappyUIManager.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        flappyUIManager.SetRestart();
    }

    public void RestartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
