using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    bool isView = true;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void Start()
    {
        if (gameOverText == null)
            Debug.LogError("GameOver Text is null");

        if (scoreText == null)
        {
            Debug.LogError("ScoreText is Null");
            return;
        }
        titleText.gameObject.SetActive(isView);
        startButton.gameObject.SetActive(isView);
        startButton.onClick.AddListener(GameStart);

        exitButton.gameObject.SetActive(isView);

        gameOverText.gameObject.SetActive(!isView);
    }

    public void GameStart()
    {
        if (startButton == null)
        {
            Debug.LogError("startButton does not Setting");
            return;
        }
        titleText.gameObject.SetActive(!isView);
        startButton.gameObject.SetActive(!isView);
        exitButton.gameObject.SetActive(!isView);
        Time.timeScale = 1f;
    }

    public void SetRestart()
    {
        gameOverText.gameObject.SetActive(isView);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
