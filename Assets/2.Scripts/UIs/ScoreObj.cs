using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreObj : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] GameObject _scoreAniPrefab;
    int _saveScore = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SaveScore(int score)
    {
        _saveScore += score;
        _scoreText.text = _saveScore.ToString();
        GameObject go = Instantiate(_scoreAniPrefab, transform);
        go.GetComponent<ScoreAni>().Initialize(score);
    }
}
