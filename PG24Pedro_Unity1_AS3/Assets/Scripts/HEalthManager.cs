using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HEalthManager : MonoBehaviour
{
    private GameManager _instance = new GameManager();
    [SerializeField] private int health = 3;

    [SerializeField] private Sprite fullLife;
    [SerializeField] private Sprite emptyLife;

    private int _remaininglifes;
    
    public Image[] lifeImg;

    private void Update()
    {
        _remaininglifes = GameManager._remainingLives;
        
        foreach (Image img in lifeImg)
        {
            img.sprite = emptyLife;
        }

        for (int i = 0; i < _remaininglifes; i++)
        {
            lifeImg[i].sprite = fullLife;
        }
    }
}
