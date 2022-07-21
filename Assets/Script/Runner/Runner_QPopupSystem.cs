using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Runner_QPopupSystem : MonoBehaviour
{
    public GameObject Popup;
    Animator anim;

    public static Runner_QPopupSystem instance {get; private set;}

    #region TEXT;
    public TextMeshProUGUI txtQues;
    public TextMeshProUGUI[] txtAnswer = new TextMeshProUGUI[6];
    #endregion;
    
    #region Random, PopupCount;
    int nPopupCnt = 0;
    int nNum1, nNum2, nCrrectAnswer, nAnswer;
    #endregion;

    System.Random random = new System.Random();

    private void Awake()
    {
        Popup.SetActive(false);
        instance = this;
        anim = Popup.GetComponent<Animator>();
    }

    public void AnswerClick()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(nCrrectAnswer == int.Parse((clickObject.GetComponentInChildren<TextMeshProUGUI>().text)))
        {
            Runner_GameManager.instance.isPlay = true;
            Runner_RespawnManager.instance.MobCnt = 0;
            ClosePopup();
        }
    }   
 
    void Question()
    {
        if(nPopupCnt == 1)
            txtQues.text = "먼저 당근케이크를 만들어야해!\n당근 케이크에 들어갈 당근" + $"{nNum1}" + "+"+ $"{nNum2}" + "개를 찾아보자!";
        if(nPopupCnt == 2)
            txtQues.text = "꽃으로 케이크를 꾸미는것도 좋을것 같아\n음.. 꽃잎이 " + $"{nNum1}" + "+"+ $"{nNum2}" + "개인 꽃을 찾아보자!";
        if(nPopupCnt == 3)
            txtQues.text = "이번엔 토마토 쥬스로 만들 토마토를 챙겨보자\n" + $"{nNum1}" + "+"+ $"{nNum2}" + "개만 있으면 돼";
        if(nPopupCnt == 4)
            txtQues.text = "음.. 토마토가 다같이 먹기엔 조금 부족한 것 같아\n" + $"{nNum1}" + "+"+ $"{nNum2}" + "개만 더 찾아보자!";
        if(nPopupCnt == 5)
        {
            Runner_GameManager.instance.isPlay = false;
            Runner_RespawnManager.instance.MobCnt = 0;
            Runner_GameManager.instance.GameEnd();
            Runner_RespawnManager.instance.GameEnd();
            
            ClosePopup();
            
            Runner_Description.instance.GameEnd();
        }
    }

    void Answer()
    {
        int nCorrect = (int)random.Next(0,6);

        for(int i=0; i<6; i++)
        {
            int nNum = 0;
            if(i == nCorrect)
                txtAnswer[i].text = $"{nCrrectAnswer}";
            else
            {
                if(i==0)
                    nNum = (int)random.Next(0,3);
                if(i==1)
                    nNum = (int)random.Next(4,6);
                if(i==2)
                    nNum = (int)random.Next(7,9);
                if(i==3)
                    nNum = (int)random.Next(10,12);
                if(i==4)
                    nNum = (int)random.Next(13,15);
                if(i==5)
                    nNum = (int)random.Next(16,18);

                if( nNum != nCrrectAnswer)
                    txtAnswer[i].text = $"{nNum}";
                else
                    txtAnswer[i].text = $"{nNum-1}";
            }
        }
    }

    public int RandomResult()
    {
        nPopupCnt++;
        
        nNum1 = (int)random.Next(1,9);
        nNum2 = (int)random.Next(1,9);
        
        return nNum1 + nNum2;
    }
    public void OpenPopup()
    {
        anim.SetBool("close", false);
        Popup.SetActive(true);
        Debug.Log("OpenPopup");

        nCrrectAnswer = RandomResult();
        Debug.Log("문제 만들기");

        Question();
        Debug.Log("Sentece 출력");
        Answer();
        Debug.Log("Answer 출력");
    }
    
    void ClosePopup()
    {
        anim.SetBool("close", true);
    }
}
