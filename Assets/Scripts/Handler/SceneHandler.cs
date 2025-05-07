using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    private static SceneHandler Instance;
    public static bool isInRange = false;
    //private string previousScene;   // test¿ë

    public Button exitButton;   // test¿ë

    public BoxCollider2D elf_Collider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if ((isInRange && Input.GetKeyDown(KeyCode.F)) || GameManager.isRestart == true)
    //    {
    //        StartCoroutine(LoadSceneAndAssignButton("FlappyScene"));
    //    }
    //}

    public void OnSceneChange()
    {
        StartCoroutine(LoadSceneAndAssignButton("FlappyScene"));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = false;
    }

    IEnumerator LoadSceneAndAssignButton(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.LoadScene(sceneName);

        yield return null;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject button = GameObject.Find("ExitButton");

        if (button != null || GameManager.isRestart == true)
        {
            GameManager.isRestart = false;

            exitButton = button.GetComponent<Button>();
            exitButton.onClick.AddListener(ReturnToPreviousScene);
        }
        else
        {
            Debug.LogWarning("ExitButton not found in the scene");
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void ReturnToPreviousScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}
