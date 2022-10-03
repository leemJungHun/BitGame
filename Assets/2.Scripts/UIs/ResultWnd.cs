using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWnd : MonoBehaviour
{

    [SerializeField] Text _txtTotalScore;

    //정보변수
    int _totalScore = 0;
    float _drawScore = 0;
    float _countingTime = 2;

    void LateUpdate()
    {
        if (_totalScore <= _drawScore)
        {
            _txtTotalScore.text = _totalScore.ToString();
        }
        else
        {
            _drawScore += _totalScore * (Time.deltaTime / _countingTime);
            _txtTotalScore.text = ((int)_drawScore).ToString();
        }
    }

    public void ClickRegameButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        SceneControlManager._instance.StartIngameScene();
    }

    public void ClickOkButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        SceneControlManager._instance.StartMainScene();
    }

    public void ClickExitButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenResultWindow(int totalScore)
    {
        _txtTotalScore.text = "0";
        _totalScore = totalScore;
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Counting_Nor);
    }
}
