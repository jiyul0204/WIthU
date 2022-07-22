using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runner_Description : MonoBehaviour
{
    public TextMeshProUGUI txtDescription;
    public GameObject oDescriptionPlayer;
    public GameObject oDescriptionPanel;
    public static Runner_Description instance;
    
    int nCnt = 0;
    bool bGameEnd = false;
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        bGameEnd = false;
        txtDescription.text = "안녕 토깽아! 다름이 아니라 요즘 날도 좋고 화창해서\n 다함께 피크닉을 가려하는데 걑이 가자!";   
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            nCnt++;   

            if(bGameEnd == true)
            {
                if(nCnt == 1)
                    txtDescription.text = "여기 아까 주운 씨앗 " + $"{Runner_Score.nScore}" + "개야! 이걸로 멋지게 꾸미고 와~\n 무화과 5개도 챙겨가!\n 그럼 피크닉 때 보자~"; 
                else
                    SceneService.Instance.LoadScene(SceneName.OutSide); 
            }
            else
            {
                if(nCnt == 1)
                    txtDescription.text = "정말?! 너도 간다니 정말 기쁘다!\n그럼 지금부터 피크닉 갈 준비를 해볼까?";    
                if(nCnt == 2)
                    txtDescription.text = "피크닉엔 뭐니뭐니해도 당근케이크와 토마토 쥬스가 빠질수 없지!\n 재료를 구하러 가자!";    
                if(nCnt == 3)
                    txtDescription.text = "아, 요즘 길에 독버섯이 종종 보이던데 잘 피해서 따라와야해!\n 그럼 출발하자~!"; 
                if(nCnt == 4)
                {
                    oDescriptionPlayer.SetActive(false);
                    oDescriptionPanel.SetActive(false);
                    txtDescription.text = "";  
                    Runner_GameManager.instance.isPlay = true;
                }
            }
        }
    }
    public void GameEnd()
    {
        txtDescription.text = "우와! 다 모았다\n 정말 고생했어 아주 즐거운 피크닉이 될거야!";  
        oDescriptionPlayer.SetActive(true);
        oDescriptionPanel.SetActive(true);
        bGameEnd = true;
        nCnt = 0;
    }
}
