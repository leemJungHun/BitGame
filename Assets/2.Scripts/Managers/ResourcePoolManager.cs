using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePoolManager : MonoBehaviour
{
    [SerializeField] GameObject[] uiPrefabs;
    [SerializeField] AudioClip[] BgmList;
    [SerializeField] AudioClip[] FxList;
    [SerializeField] string[] tiostrings;
    static ResourcePoolManager uniqueInstance;
    private void Awake()
    {
        uniqueInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static ResourcePoolManager instance
    {
        get { return uniqueInstance; }
    }

    public AudioClip GetBgmClipFormType(DefineHelper.eBgmType type)
    {
        return BgmList[(int)type];
    }

    public AudioClip GetFxClipFormType(DefineHelper.eFxType type)
    {
        return FxList[(int)type];
    }
    public string GetRandomTip()
    {
        int idx = Random.Range(0, tiostrings.Length);

        return tiostrings[idx];
    }

    public GameObject GetUIPrefabFromType(DefineHelper.eUIwindowtype wndtype)
    {
        return uiPrefabs[(int)wndtype];
    }
}
