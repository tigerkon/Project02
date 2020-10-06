﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
        if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll(); // deletes all saved records
        _highScoreTextView.text = "0"; // the number you want to reset your highscore to..
    }

}
