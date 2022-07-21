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
        ScriptText.text = "���� ģ����� �Բ� ķ���� ��������!\n�츱 ���� ���� ���� ������ ���ش��� �� �ְڴ�?";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TouchCnt == 0)
            {
                ScriptText.text = "ȭ�鿡 ���� �����Ұž�!\n���� ������ ������ Ŭ���ϸ� ���� �� �־�!";
                TouchCnt++;
            }
            else if (TouchCnt == 1)
            {
                ScriptText.text = "�� 10���� ������ �ʿ���!\n����! �� �Ҽ��־�!";
                TouchCnt++;
            }
            else if(TouchCnt ==2 )
            {
                HowToPlayPopupPanel.SetActive(!HowToPlayPopupPanel.activeSelf);
                ScriptText.text = "���� ��ũ�п� ������?\n������ �ٸ�Ҵ�?";
                TouchCnt++;
            }
            else if(TouchCnt==4)
            {
                ScriptText.text = "�����߾�!\n10���� ��� ����־�����!";
                TouchCnt++;
            }
            else if(TouchCnt ==5)
            {
                ScriptText.text = "���п� ��ũ���� �� �� �־�!\n������ ���� 2��, ��� 2���� �ٰ�!";
                TouchCnt = 9;
            }
            else if(TouchCnt==8)
            {
                ScriptText.text = "������ ���� �����ϳ�! �׷��� ����༭ ����!\n������ ���� 1���� �ٰ�!";
                TouchCnt = 9;
            }
            else if(TouchCnt==9)
            {
                SceneService.Instance.LoadScene(SceneName.Main);
            }
        }
    }
}
