using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public List<GameObject> LifeIcons = new List<GameObject>();
    public GameObject GameOverPanel;
    public GameObject StartGamePanel;
    public GameObject PausePanel;

    private void Start()
    {
        HideGameOver();
        HidePauseGame();

        ShowStartGame();
    }
    public void UpdateScoreText(int _value)
    {
        scoreText.text = _value.ToString();
    }

    public void UpdateLives(int _value)
    {
		for (int i = LifeIcons.Count - 1; i >= 0; i--)
		{
            LifeIcons[i].SetActive(_value >= i);
        }
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        GameOverPanel.SetActive(false);
    }

    public void ShowStartGame()
    {
        StartGamePanel.SetActive(true);
    }

    public void HideStartGame()
    {
        StartGamePanel.SetActive(false);
    }

    public void ShowPauseGame()
    {
        PausePanel.SetActive(true);
    }

    public void HidePauseGame()
    {
        PausePanel.SetActive(false);
    }
}
