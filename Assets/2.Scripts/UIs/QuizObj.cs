using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizObj : MonoBehaviour
{
    [SerializeField] Text[] _quizTexts;
    int _maxValue = 0;
    List<int> answerList;

    public bool _isAnswer(int answer)
    {
        return answerList.Contains(answer);
    }

    public void QuizSetting(DefineHelper.eIngameDifficult difficult)
    {
        answerList = new List<int>();
        for(int i = 0; i < _quizTexts.Length; i++)
        {
            _quizTexts[i].text = "";
        }
        switch (difficult)
        {
            case DefineHelper.eIngameDifficult.EASY:
                _maxValue = 16;
                break;
            case DefineHelper.eIngameDifficult.NORMAL:
                _maxValue = 64;
                break;
            case DefineHelper.eIngameDifficult.HARD:
                _maxValue = 256;
                break;
        }

        int ranCount = 0;
        int ranQuizCount = 0;
        bool textSucces = false;
        bool quizSucces = false;
        List<int> ranTextList = new List<int>();
        List<int> ranQuizList = new List<int>();

        //중복 방지
        while (true)
        {
            //텍스트 랜덤
            if (!textSucces)
            {
                int ran = Random.Range(0, _quizTexts.Length);
                if (!ranTextList.Contains(ran))
                {
                    ranTextList.Add(ran);
                    ranCount++;
                }
                if (ranCount == 3) textSucces = true;
            }
            //숫자 랜덤
            if (!quizSucces)
            {
                int ran = Random.Range(1, _maxValue);
                if (!ranQuizList.Contains(ran))
                {
                    ranQuizList.Add(ran);
                    ranQuizCount++;
                }
                if (ranQuizCount == 3) quizSucces = true;
            }
            if (textSucces && quizSucces) break;
        }

        for (int i = 0; i < ranTextList.Count; i++)
        {
            _quizTexts[ranTextList[i]].text = ranQuizList[i].ToString();
            answerList.Add(ranQuizList[i]);
        }

    }
}
