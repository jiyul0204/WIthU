using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderTimer : MonoBehaviour
{
    public TextMeshProUGUI slTimer;
    static public float fSliderBarTime;
    static public int InitTime;
    [SerializeField]
    private GameObject HowToPlayPopupPanel;

    void Start()
    {
        fSliderBarTime = 80;
        int nTime = (int)fSliderBarTime;
        InitTime = (int)fSliderBarTime;
        slTimer.text = nTime.ToString() + "√ ";
    }
    void Update()
    {
        if(CreateCalc.nAnsNumCnt!=10 && ChangeStroy.TouchCnt>=3)
        {
            if (fSliderBarTime > 0.0f)
            {
                fSliderBarTime -= Time.deltaTime;
                int nTime = (int)fSliderBarTime;
                slTimer.text = nTime.ToString() + "√ ";
            }
            else
            {
                ChangeStroy.TouchCnt = 8;
                HowToPlayPopupPanel.SetActive(true);
            }
        }
    }
}
