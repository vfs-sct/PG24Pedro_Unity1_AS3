using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    [SerializeField] private GameObject _gameOverScreen;

    [SerializeField] private GameObject _winingScreen;

    [SerializeField] private GameObject _playerPrefab;
    
    [SerializeField] private int _maxLives = 3;

    [SerializeField] private int _remainingLives;
    
    


    void Start()
    {
        _remainingLives = _maxLives;
        _gameOverScreen.SetActive(false);
        _winingScreen.SetActive(false);
    }

    private void PlayerDeath()
    {

    }
    
    void Update()
    {
        int currScore = ScoreCount.GetScore();

        if (currScore == 7)
        {
            _winingScreen.SetActive(true);   
        }
    }
    
    

}
