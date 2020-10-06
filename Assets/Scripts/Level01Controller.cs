using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject pausePanel;
    

    int _currentScore;
    private void Start()
    {
        
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New High Score" + _currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeLevel()
    {
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
