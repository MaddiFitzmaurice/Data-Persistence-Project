using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // Input Field
    public GameObject inputText;
    public Text bestScoreText;

    private void Start()
    {
        MenuManager.Instance.LoadHighScore();
        UpdateBestScoreText();
    }
    public void StartGame()
    {
        SaveName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void SaveName()
    {
        MenuManager.Instance.playerName = inputText.GetComponent<Text>().text;
    }

    void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + MenuManager.Instance.highScoreName +
            ": " + MenuManager.Instance.highScore;
    }
}
