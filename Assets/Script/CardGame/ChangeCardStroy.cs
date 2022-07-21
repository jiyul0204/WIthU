using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class ChangeCardStroy : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScriptText;
    [SerializeField]
    private GameObject HowToPlayPopupPanel;

    static public int TouchCnt = 0;
    void Start()
    {
        TouchCnt = 0;
        ScriptText.text = "같이 카드게임하자!\n규칙을 설명해줄게!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TouchCnt == 0)
            {
                ScriptText.text = "나무 판자 가운데에 숫자 카드가 올라갈거야\n네가 가지고있는 숫자카드를 조합해서 식을만들어!";
                TouchCnt++;
            }
            else if (TouchCnt == 1)
            {
                ScriptText.text = "만든 식의 답이 가운데 놓은 숫자 카드와 비교해서 상대방보다 더 가까우면 이기는 게임이야!";
                TouchCnt++;
            }
            else if(TouchCnt == 2)
            {
                ScriptText.text = "단, 네가 한번 쓴 숫자카드는 사라져! \n대신 턴이 끝날때마다 새로운 숫자카드 2장을 받게되!";
                TouchCnt++;
            }
            else if (TouchCnt == 3)
            {
                ScriptText.text = "지금부터 2부터9까지의 수를 무작위로 나눠줄게\n카드 덱을 고르면 게임이 시작돼!";
                TouchCnt++;
            }
            else if (TouchCnt == 4)
            {
                HowToPlayPopupPanel.SetActive(!HowToPlayPopupPanel.activeSelf);
                ScriptText.text = "정말 재밌는 게임이였어!\n과연 게임결과는?!";
                TouchCnt++;
            }
           else if(TouchCnt == 6)
           {
                if(GetUserCard.IsCorrect > GetUserCard.IsOpCorrect)
                    ScriptText.text = "축하해! 네가 이겼어!\n포도3개와 무화과 3개를 줄게!";
                else if(GetUserCard.IsCorrect == GetUserCard.IsOpCorrect)
                    ScriptText.text = "수고했어! 좋은 결과네!\n포도2개와 무화과 2개를 줄게!";
                else
                    ScriptText.text = "졌지만 잘싸웠어!\n포도1개와 무화과 1개를 줄게!";
                TouchCnt++;
            }
           else if(TouchCnt==7)
                SceneService.Instance.LoadScene(SceneName.Main);

        }
    }
}
