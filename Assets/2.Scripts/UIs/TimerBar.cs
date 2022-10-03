using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerBar : MonoBehaviour
{
    Slider _slider;
    [SerializeField] Image _fill;
    [SerializeField] Text _limitTimeText;
    void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLimitTime(float limitTime)
    {
        _slider.maxValue = limitTime;
        _limitTimeText.gameObject.SetActive(false);
        _slider.gameObject.SetActive(false);
    }

    public void SetTimer(float time)
    {
        _limitTimeText.text = ((int)time).ToString()+"s";
        _slider.value = time;
        if (time <= 11)
        {
            _limitTimeText.color = Color.red;
            _fill.color = Color.red;
        }
    }

    public void OpenTimer()
    {
        _limitTimeText.gameObject.SetActive(true);
        _slider.gameObject.SetActive(true);
    }
}
