using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitBlanksSetting : MonoBehaviour
{
    [SerializeField] GameObject _bitPrefab;
    float _startX = 0f;
    float _moveX = 150f;
    int _bitCount = 0;
    Dictionary<int, BitButtonObj> _bitList;
    


    void Start()
    {
        _bitList = new Dictionary<int, BitButtonObj>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetResult()
    {
        int result = 0;
        foreach (KeyValuePair<int, BitButtonObj> item in _bitList)
        {
            if(item.Value._bit == 1)
            {
                result += item.Key;
            }
        }
        return result;
    }

    public void ResumeButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        foreach (KeyValuePair<int, BitButtonObj> item in _bitList)
        {
            item.Value.initialization(item.Key);
        }
    }

    public void SetAnswerBlanks(DefineHelper.eIngameDifficult difficult)
    {
        switch (difficult)
        {
            case DefineHelper.eIngameDifficult.EASY:
                _startX = 150;
                _bitCount = 4;
                break;
            case DefineHelper.eIngameDifficult.NORMAL:
                _startX = 300;
                _bitCount = 6;
                break;
            case DefineHelper.eIngameDifficult.HARD:
                _startX = 450;
                _bitCount = 8;
                break;
        }
        for (int i = 0; i < _bitCount; i++)
        {
            GameObject go = Instantiate(_bitPrefab, transform);
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector3(_startX - (_moveX * i), rect.anchoredPosition.y);
            BitButtonObj bitButtonObj = go.GetComponent<BitButtonObj>();
            int value = (int)Mathf.Pow(2, i);
            bitButtonObj.initialization(value);
            _bitList.Add(value, bitButtonObj);
        }
    }
}
