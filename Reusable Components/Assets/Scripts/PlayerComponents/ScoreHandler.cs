using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private float _score;

    public float Score
    {
        get => _score;
    }

    public void AddScore(float pScore)
    {
        _score += pScore;
    }
}
