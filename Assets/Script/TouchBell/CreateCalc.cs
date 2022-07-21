using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CreateCalc : MonoBehaviour
{
    [SerializeField]
    private GameObject HowToPlayPopupPanel;

    #region Inform
    public MODE DiffLevel;
    Operation Operate;
    public int UserLevel;
    #endregion

    #region Quest
    public TextMeshProUGUI Quest;
    public Button[] Btn_AnsNum = new Button[6];
    int nRealAnsIndex = -1; //현재 답 인덱스
    #endregion

    #region Cal_Text
    public TextMeshProUGUI FirstNum;
    public TextMeshProUGUI MidNum;
    public TextMeshProUGUI OperText;
    public TextMeshProUGUI[] Txt_AnsNum = new TextMeshProUGUI[6];
    static public int nAnsNumCnt = 0;
    #endregion

    #region Quiz_Num(static)
    public static int nFirstNum = 0;                          //문제의 수
    public static int nMidNum = 0;
    public static int AnsNum = 0;                               //맞춰야 할 수
    #endregion
    enum Operation
    {
        MULTIPLY,
        DIVISION
    }

    void Start()
    {
        BindView();
        CreateNum();
        ShowNum();
    }

    void Calculate(Operation oper, int a, int b)
    {
        switch (oper)
        {
            case Operation.MULTIPLY:
                nFirstNum = a;
                nMidNum = b;
                AnsNum = a * b;
                break;
            case Operation.DIVISION:
                nFirstNum = a * b;
                nMidNum = b;
                AnsNum = a;
                break;
        }
    }
    void CreateNum()
    {
        //DiffLevel = SetMode.DecideMode(UserLevel); //아이의 레벨은 메인 만들면 받아와야함
        if (DiffLevel == MODE.EASY)
            Operate = Operation.MULTIPLY;
        else if(DiffLevel ==MODE.NORMAL)
            Operate = Operation.DIVISION;
        else if(DiffLevel ==MODE.HARD)
            Operate = (Operation)Random.Range((int)Operation.MULTIPLY, (int)Operation.DIVISION+1);

        Calculate(Operate, Random.Range(2, 10), Random.Range(2, 10));

        if (Operate == Operation.MULTIPLY)
            OperText.text = "X";
        else if(Operate ==Operation.DIVISION)
            OperText.text = "÷";
    }

    int SetLogNum(Operation Oper)
    {
        int RNum=0;
        if(Oper == Operation.MULTIPLY)
            RNum = Random.Range(2, 82);
        else if(Oper == Operation.DIVISION)
            RNum = Random.Range(2,10);
        return RNum;
    }
    static public void ChangeNum(int Num)
    {
        nAnsNumCnt = Num;
    }

    void ShowNum()
    {
        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
        FirstNum.text = nFirstNum.ToString();
        MidNum.text = nMidNum.ToString();

        nRealAnsIndex = Random.Range(0, 6);
        int nRandomNum = 0;
        for (int i = 0; i < 6; i++)
        {
            do
            {
                nRandomNum = SetLogNum(Operate);
            } while (nRandomNum == AnsNum);

            Txt_AnsNum[i].text = $"{nRandomNum}";
            Txt_AnsNum[nRealAnsIndex].text = $"{AnsNum}";

            for (int j = 0; j < i; j++)
            {
                if (int.Parse(Txt_AnsNum[j].text) == nRandomNum)
                {
                    i -= 1;
                    break;
                }
            }

        }
    }

    private void BindView()
    {
        Btn_AnsNum[0].OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (0 == nRealAnsIndex)
                {
                    nAnsNumCnt++;
                    if (nAnsNumCnt == 10)
                    {
                        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
                        HowToPlayPopupPanel.SetActive(true);
                        ChangeStroy.TouchCnt = 4;
                    }
                    else
                    {
                        CreateNum();
                        ShowNum();
                    }
                }

            })
            .AddTo(gameObject);
        Btn_AnsNum[1].OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (1 == nRealAnsIndex)
                {
                    nAnsNumCnt++;
                    if (nAnsNumCnt == 10)
                    {
                        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
                        HowToPlayPopupPanel.SetActive(true);
                        ChangeStroy.TouchCnt = 4;
                    }
                    else
                    {
                        CreateNum();
                        ShowNum();
                    }
                }

            })
            .AddTo(gameObject);

        Btn_AnsNum[2].OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (2 == nRealAnsIndex)
                {
                    nAnsNumCnt++;
                    if (nAnsNumCnt == 10)
                    {
                        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
                        HowToPlayPopupPanel.SetActive(true);
                        ChangeStroy.TouchCnt = 4;
                    }
                    else
                    {
                        CreateNum();
                        ShowNum();
                    }
                }

            })
            .AddTo(gameObject);
        Btn_AnsNum[3].OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (3 == nRealAnsIndex)
                {
                    nAnsNumCnt++;
                    if (nAnsNumCnt == 10)
                    {
                        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
                        HowToPlayPopupPanel.SetActive(true);
                        ChangeStroy.TouchCnt = 4;
                    }
                    else
                    {
                        CreateNum();
                        ShowNum();
                    }
                }

            })
            .AddTo(gameObject);
        Btn_AnsNum[4].OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (4 == nRealAnsIndex)
                {
                    nAnsNumCnt++;
                    if (nAnsNumCnt == 10)
                    {
                        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
                        HowToPlayPopupPanel.SetActive(true);
                        ChangeStroy.TouchCnt = 4;
                    }
                    else
                    {
                        CreateNum();
                        ShowNum();
                    }
                }

            })
            .AddTo(gameObject);
        Btn_AnsNum[5].OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (5 == nRealAnsIndex)
                {
                    nAnsNumCnt++;
                    if (nAnsNumCnt == 10)
                    {
                        Quest.text = "장작(" + $"{nAnsNumCnt}" + " / 10)";
                        HowToPlayPopupPanel.SetActive(true);
                        ChangeStroy.TouchCnt = 4;
                    }
                    else
                    {
                        CreateNum();
                        ShowNum();
                    }
                }

            })
            .AddTo(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
