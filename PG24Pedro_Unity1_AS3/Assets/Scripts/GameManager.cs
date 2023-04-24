using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    /*private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }*/

    [SerializeField] private GameObject _gameOverScreen;

    [SerializeField] private GameObject _winingScreen;

    [SerializeField] private GameObject _playerPrefab;
    
    [SerializeField] private int _maxLives = 2;

    [SerializeField] private int goal = 5;
    
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public static int _remainingLives;

    public static bool isAlive = true;

    public static bool hasWon = false;
    
    
    public void Start()
    {
        _remainingLives = _maxLives;
        _gameOverScreen.SetActive(false);
        _winingScreen.SetActive(false);
    }

    private void PlayerDeath()
    {
        _gameOverScreen.SetActive(true);
        ScoreCount.SetScore(0);
        _remainingLives = _maxLives;

    }
    
    void Update()
    {
        int currScore = ScoreCount.GetScore();

        if (currScore == goal)
        {
            _winingScreen.SetActive(true);
            hasWon = true;
        }

        if (!isAlive && !hasWon)
        {
            PlayerDeath();
        }

        _scoreText.text = currScore.ToString();
    }

    public static void DoDamage()
    {
        if (_remainingLives > 0)
        {
            --_remainingLives;
        }

        else
        {
            isAlive = false;
        }
    
    }

    public void Restart()
    {
        isAlive = true;
        hasWon = false;
        _gameOverScreen.SetActive(false);
        _winingScreen.SetActive(false);
        ScoreCount.SetScore(0);
        _remainingLives = _maxLives;

        _playerPrefab.GetComponent<ShipController>().respawnPlayer();
        
    }
}
