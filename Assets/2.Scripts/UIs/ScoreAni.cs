using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAni : MonoBehaviour
{
    float _checkTime = 0;
    Vector3 _targetPos;
    float _moveSpeed = 0.03f;
    Text _scoreAniText;
    Color _fadeColor;

    void Awake()
    {
        _scoreAniText = GetComponent<Text>();
        _fadeColor = _scoreAniText.color;
        _targetPos = new Vector3(transform.position.x, transform.position.y+150, transform.position.z);
    }

    public void Initialize(int score)
    {
        if (score == 0)
        {
            _scoreAniText.color = Color.red;
            _fadeColor = _scoreAniText.color;
        }
        _scoreAniText.text = "+" + score.ToString();
        
    }

    void Update()
    {
        if (_checkTime < 1)
        {
            _checkTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, _targetPos, _checkTime * _moveSpeed);
            _fadeColor.a = Mathf.Lerp(1, 0, _checkTime);
            _scoreAniText.color = _fadeColor;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
