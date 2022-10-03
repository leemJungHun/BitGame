using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineHelper
{
    #region [Manager Info]
    public enum _eSceneIndex
    {
        none,
        MainScene,
        IngameScene
    }
    public enum eIngameDifficult
    {
        EASY = 0,
        NORMAL,
        HARD
    }

    public enum eIngameState
    {
        none = 0,
        COUNT,
        PLAY,
        END,
        RESULT,


        state_Count
    }
    #endregion

    #region [UI State Info]
    public enum eMessageBoxKind
    {
        COUNTER = 0,
        MESSAGE
    }

    public enum eResultCounting
    {
        none = 0,
        IndividualScore,
        TotalScore,
        Complete
    }

    public enum eBgmType
    {
        Main = 0,
        Ingame,


        max_count
    }
    public enum eFxType
    {
        Click_tock = 0,
        Counting_Nor,
        Failed,
        Answer
    }

    public enum eUIwindowtype
    {
        LoaddingWnd = 0,
        ResultWnd,
        OptionWnd,

        max_count
    }
    #endregion
}
