using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserInfoManager : MonoBehaviour
{
    static UserInfoManager uniqueInstance;
    Dictionary<string, string> optionInfo = new Dictionary<string, string>();
    public static UserInfoManager instance
    {
        get { return uniqueInstance; }
    }
    public int newStageNumber
    {
        get; set;
    }
    public int clearStage
    {
        get; set;
    }
    private void Awake()
    {
        uniqueInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void OptionLoad()
    {
        if (File.Exists("Option.txt"))
        {
            StreamReader sr = File.OpenText("Option.txt");
            while (sr.Peek() >= 0)
            {
                optionInfo.Add(sr.ReadLine(), sr.ReadLine());
            }
            sr.Close();

            SoundManager.instance.GetSetBgmVolume = float.Parse(optionInfo["Bgm"]);
            SoundManager.instance.GetSetSfxVolume = float.Parse(optionInfo["Sfx"]);
            SoundManager.instance.GetSetBgmMult = bool.Parse(optionInfo["BgmMute"]);
            SoundManager.instance.GetSetSfxMute = bool.Parse(optionInfo["SfxMute"]);
        }
        else
        {
            NewOption();
        }
        optionInfo.Clear();
    }
    public void OptionSave(Dictionary<string, string> option)
    {
        if (File.Exists("Option.txt"))
        {
            //StreamReader sr = File.OpenText("Option.txt");
            //while (sr.Peek() >= 0)
            //{
            //    optionInfo.Add(sr.ReadLine(), sr.ReadLine());
            //}
            //sr.Close();

            StreamWriter sw = new StreamWriter("Option.txt");
            foreach (string key in option.Keys)
            {

                sw.WriteLine(key);
                sw.WriteLine(option[key]);

            }
            sw.Close();
        }
    }

    public void NewOption()
    {
        StreamWriter sw = new StreamWriter("Option.txt");
        sw.WriteLine("Bgm");
        sw.WriteLine("1");
        sw.WriteLine("Sfx");
        sw.WriteLine("1");
        sw.WriteLine("BgmMute");
        sw.WriteLine("false");
        sw.WriteLine("SfxMute");
        sw.WriteLine("false");
        sw.Close();
    }
}
