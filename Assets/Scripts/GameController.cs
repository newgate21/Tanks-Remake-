using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score = 0;
    public int Lives = 3;
    public int InitialLives = 3;

    public UIController UIController;
    public Ball Ball;
    public Vector3 BallDefaultPosition;
    public AudioController audioController;
    public GameObject ExplosionPrefab;
    public BlockController blockController;

    private bool isPlaying = false;
    public bool IsPlaying { get { return isPlaying; } }
    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }

    public void Start()
    {
        UIController.UpdateScoreText(Score);
        UIController.UpdateLives(Lives);

        PauseGame();
    }

    public void AddScore(int _value)
    {
        Score += _value;
        UIController.UpdateScoreText(Score);
    }

    public void BallLost()
    {
        // Reset ball
        Ball.ResetBall(BallDefaultPosition);

        // lose a life
        Lives--;
        UIController.UpdateLives(Lives);
        if (Lives < 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        UIController.ShowGameOver();
        isPlaying = false;
        PauseGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        ResetGame();
        UnpauseGame();
    }

    void ResetGame()
    {
        Score = 0;
        Lives = InitialLives;
        Ball.ResetBall(BallDefaultPosition);
        UIController.UpdateLives(Lives);
        UIController.UpdateScoreText(Score);
        UIController.HideGameOver();
        UIController.HideStartGame();
        //blockController.ResetBlocks();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        if (isPlaying)
        {
            UIController.ShowPauseGame();
        }
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        UIController.HidePauseGame();
    }

    public void QuitGame()
    {
        isPlaying = false;
        PauseGame();
        UIController.HideGameOver();
        UIController.HidePauseGame();
        UIController.ShowStartGame();
    }
}
