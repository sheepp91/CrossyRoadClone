using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public Text scoreLabel; 
    [SerializeField] private int score = 0;

    public static PointSystem Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        ++score;
        scoreLabel.text = score.ToString();
    }
}
