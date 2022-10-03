using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] Color[] _difficultyColor;
    [SerializeField] Text _difficultyText;
    bool _toggleOn = false;
    GameObject _option;
    public DefineHelper.eIngameDifficult _eInagemeDifficult
    {
        get; set;
    }

    static MainSceneManager _uniqueInstance;



    void Awake()
    {
        _uniqueInstance = this;
    }
    

    public static MainSceneManager _instance
    {
        get { return _uniqueInstance; }
    }

    public void OptionOpen()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        if (_option == null)
        {
            _option = Instantiate(ResourcePoolManager.instance.GetUIPrefabFromType(DefineHelper.eUIwindowtype.OptionWnd));
        }
        else
        {
            _option.SetActive(true);
        }
        
    }
    
    public void ChangeDifficult(int difficult)
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        _toggleOn = true;
        _eInagemeDifficult = (DefineHelper.eIngameDifficult)difficult;
        _difficultyText.color = _difficultyColor[difficult];
        switch (_eInagemeDifficult)
        {
            case DefineHelper.eIngameDifficult.EASY:
                _difficultyText.text = "EASY";
                break;
            case DefineHelper.eIngameDifficult.NORMAL:
                _difficultyText.text = "NORMAL";
                break;
            case DefineHelper.eIngameDifficult.HARD:
                _difficultyText.text = "HARD";
                break;
        }
    }
    public void StartButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        if (_toggleOn)
        {
            SceneControlManager._instance.StartIngameScene();
        }
    }

    public void ExitButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
