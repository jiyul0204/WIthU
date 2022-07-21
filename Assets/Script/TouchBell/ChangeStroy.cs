using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeStroy : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScriptText;
    [SerializeField]
    private GameObject HowToPlayPopupPanel;

    static public int TouchCnt=0;
    void Start()
    {
        TouchCnt = 0;
        ScriptText.text = "동물 친구들과 함께 캠핑을 가려고해!\n우릴 위해 불을 지필 장작을 구해다줄 수 있겠니?";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TouchCnt == 0)
            {
                ScriptText.text = "화면에 식이 등장할거야!\n식의 정답인 장작을 클릭하면 모을 수 있어!";
                TouchCnt++;
            }
            else if (TouchCnt == 1)
            {
                ScriptText.text = "총 10개의 장작이 필요해!\n힘내! 넌 할수있어!";
                TouchCnt++;
            }
            else if(TouchCnt ==2 )
            {
                HowToPlayPopupPanel.SetActive(!HowToPlayPopupPanel.activeSelf);
                ScriptText.text = "이제 피크닉에 가볼까?\n장작은 다모았니?";
                TouchCnt++;
            }
            else if(TouchCnt==4)
            {
                ScriptText.text = "수고했어!\n10개를 모두 모아주었구나!";
                TouchCnt++;
            }
            else if(TouchCnt ==5)
            {
                ScriptText.text = "덕분에 피크닉을 갈 수 있어!\n선물로 포도 2개, 사과 2개를 줄게!";
                TouchCnt = 9;
            }
            else if(TouchCnt==8)
            {
                ScriptText.text = "장작이 조금 부족하네! 그래도 모아줘서 고마워!\n선물로 포도 1개를 줄게!";
                TouchCnt = 9;
            }
            else if(TouchCnt==9)
            {
                SceneService.Instance.LoadScene(SceneName.Main);
            }
        }
    }
}
