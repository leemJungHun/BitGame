using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessageBox : MonoBehaviour
{
    [SerializeField] Sprite[] _countImages;
    Text _txtMessage;
    Image _counterImage;
    int _counter = 0;
    float _time;
    int scaleNum = 1;

    void Awake()
    {
        _txtMessage = this.GetComponent<Text>();
        _counterImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void OpenMessageBox(string msg, DefineHelper.eMessageBoxKind type = DefineHelper.eMessageBoxKind.MESSAGE, int count = 3)
    {
        gameObject.SetActive(true);
        switch (type)
        {
            case DefineHelper.eMessageBoxKind.MESSAGE:
                _txtMessage.text = "GameStart!";
                _counterImage.gameObject.SetActive(false);
                break;
            case DefineHelper.eMessageBoxKind.COUNTER:
                _txtMessage.text = "";
                _counterImage.gameObject.SetActive(true);
                _counter = count;
                break;
        }

        _txtMessage.text = msg;
    }

    public void SetCounting(int _count)
    {
        if (_counter - _count != 0)
        {
            if (_counterImage.transform.localScale.x >= 0)
            {
                _counterImage.transform.localScale -= Vector3.one * Time.deltaTime * scaleNum;
            }
            if (_countImages.Length > _count && _counterImage.sprite != _countImages[_count])
            {
                _counterImage.gameObject.transform.localScale = Vector3.one;
                _counterImage.sprite = _countImages[_count];
            }
        }
        else
        {
            OpenMessageBox("GameStart!!");
        }

    }

    public void CloseMessgeBox()
    {
        gameObject.SetActive(false);
    }
}
