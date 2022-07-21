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
        ScriptText.text = "���� ī���������!\n��Ģ�� �������ٰ�!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TouchCnt == 0)
            {
                ScriptText.text = "���� ���� ����� ���� ī�尡 �ö󰥰ž�\n�װ� �������ִ� ����ī�带 �����ؼ� ���������!";
                TouchCnt++;
            }
            else if (TouchCnt == 1)
            {
                ScriptText.text = "���� ���� ���� ��� ���� ���� ī��� ���ؼ� ���溸�� �� ������ �̱�� �����̾�!";
                TouchCnt++;
            }
            else if(TouchCnt == 2)
            {
                ScriptText.text = "��, �װ� �ѹ� �� ����ī��� �����! \n��� ���� ���������� ���ο� ����ī�� 2���� �ްԵ�!";
                TouchCnt++;
            }
            else if (TouchCnt == 3)
            {
                ScriptText.text = "���ݺ��� 2����9������ ���� �������� �����ٰ�\nī�� ���� ���� ������ ���۵�!";
                TouchCnt++;
            }
            else if (TouchCnt == 4)
            {
                HowToPlayPopupPanel.SetActive(!HowToPlayPopupPanel.activeSelf);
                ScriptText.text = "���� ��մ� �����̿���!\n���� ���Ӱ����?!";
                TouchCnt++;
            }
           else if(TouchCnt == 6)
           {
                if(GetUserCard.IsCorrect > GetUserCard.IsOpCorrect)
                    ScriptText.text = "������! �װ� �̰��!\n����3���� ��ȭ�� 3���� �ٰ�!";
                else if(GetUserCard.IsCorrect == GetUserCard.IsOpCorrect)
                    ScriptText.text = "�����߾�! ���� �����!\n����2���� ��ȭ�� 2���� �ٰ�!";
                else
                    ScriptText.text = "������ �߽ο���!\n����1���� ��ȭ�� 1���� �ٰ�!";
                TouchCnt++;
            }
           else if(TouchCnt==7)
                SceneService.Instance.LoadScene(SceneName.Main);

        }
    }
}
