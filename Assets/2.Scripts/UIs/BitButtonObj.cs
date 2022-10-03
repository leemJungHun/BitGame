using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitButtonObj : MonoBehaviour
{
    [SerializeField] Text _bitValueText;
    Text _bitText;
    
    public int _bit
    {
        get; set;
    }

    public void initialization(int value)
    {
        _bitText = transform.GetChild(0).GetComponent<Text>();
        _bit = 0;
        _bitValueText.text = value.ToString();
        _bitText.text = _bit.ToString();
    }

    public void ButtonClick()
    {
        SoundManager.instance.PlaySfxSoundOneShot(DefineHelper.eFxType.Click_tock);
        if (_bit == 0)
        {
            _bit = 1;
            _bitText.text = _bit.ToString();
        }
        else
        {
            _bit = 0;
            _bitText.text = _bit.ToString();
        }
    }
}
