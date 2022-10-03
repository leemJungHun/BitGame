using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    static InGameManager _uniqueInstance;
    StartMessageBox _msgBox;
    TimerBar _timerBar;
    BitBlanksSetting _answerBox;
    QuizObj _quizBox;
    ScoreObj _scoreObj;


    // 정보 변수
    DefineHelper.eIngameState _currentState;
    DefineHelper.eIngameDifficult _currentDifficult;
    float _passTime = 0;
    int _startCount = 3;
    float _limitPlayTime = 60; //플레이 제한 시간
    float _endDelayTime = 2;
    int _resultScore;

    public static InGameManager _instance
    {
        get { return _uniqueInstance; }
    }

    void Awake()
    {
        _uniqueInstance = this;
    }

    public void InitializeSettings(DefineHelper.eIngameDifficult difficult)
    {

        _limitPlayTime = 60;

        _currentDifficult = difficult;

        GameObject go = null;
        go = GameObject.FindGameObjectWithTag("UIMessageBox");
        _msgBox = go.GetComponent<StartMessageBox>();
        go = GameObject.FindGameObjectWithTag("UITimerBar");
        _timerBar = go.GetComponent<TimerBar>();
        _timerBar.SetLimitTime(_limitPlayTime);
        go = GameObject.FindGameObjectWithTag("UIAnswerBox");
        _answerBox = go.GetComponent<BitBlanksSetting>();
        _answerBox.SetAnswerBlanks(_currentDifficult);
        go = GameObject.FindGameObjectWithTag("UIQuizBox");
        _quizBox = go.GetComponent<QuizObj>();
        go = GameObject.FindGameObjectWithTag("UIScoreBox");
        _scoreObj = go.GetComponent<ScoreObj>();

        StartGameCount(_startCount);

    }

    void Update()
    {
        switch (_currentState)
        {
            case DefineHelper.eIngameState.COUNT:
                _passTime += Time.deltaTime;
                _msgBox.SetCounting((int)_passTime);
                if (_startCount - _passTime <= -1)
                {
                    PlayGame();
                }
                break;
            case DefineHelper.eIngameState.PLAY:
                _limitPlayTime -= Time.deltaTime;
                _timerBar.SetTimer(_limitPlayTime);
                if (_limitPlayTime <= 0)
                {
                    EndGame();
                }
                //_timerBox.SettingTimer(_limitPlayTime);
                break;
            case DefineHelper.eIngameState.END:
                _passTime += Time.deltaTime;
                if (_passTime >= _endDelayTime)
                {
                    ResultGame();
                }
                break;
        }
    }

    public void OKButton()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        if (_quizBox._isAnswer(_answerBox.GetResult()))
        {
            SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Answer);
            _resultScore += _answerBox.GetResult();
            _scoreObj.SaveScore(_answerBox.GetResult());
        }
        else
        {
            SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Failed);
            _scoreObj.SaveScore(0);
        }
        _answerBox.ResumeButton();
        _quizBox.QuizSetting(_currentDifficult);
    }

    void StartGameCount(int count)
    {
        _currentState = DefineHelper.eIngameState.COUNT;
        _msgBox.OpenMessageBox("", DefineHelper.eMessageBoxKind.COUNTER, count);
    }

    void PlayGame()
    {
        _msgBox.CloseMessgeBox();
        _timerBar.OpenTimer();
        _currentState = DefineHelper.eIngameState.PLAY;
        _quizBox.QuizSetting(_currentDifficult);
    }

    void EndGame()
    {
        _currentState = DefineHelper.eIngameState.END;
        _passTime = 0;
        _msgBox.OpenMessageBox("Time Over!!");
    }

    void ResultGame()
    {
        _currentState = DefineHelper.eIngameState.RESULT;
        _msgBox.CloseMessgeBox();
        // 종료창을 생성
        GameObject go = Instantiate(ResourcePoolManager.instance.GetUIPrefabFromType(DefineHelper.eUIwindowtype.ResultWnd));
        ResultWnd resultWnd = go.GetComponent<ResultWnd>();
        resultWnd.OpenResultWindow(_resultScore);
        
    }

}
