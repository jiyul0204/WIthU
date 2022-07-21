using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;
public class GetUserCard : MonoBehaviour
{
    #region Card
    [SerializeField]
    private Button CardDeck1;
    [SerializeField]
    private Button CardDeck2;
    [SerializeField]
    private GameObject FirstMainPanel;
    [SerializeField]
    private GameObject GamePanel;
    [SerializeField]
    private TextMeshProUGUI Anounce;
    #endregion

    [SerializeField]
    private TextMeshProUGUI[] CardUser = new TextMeshProUGUI[5];
    [SerializeField]
    private TextMeshProUGUI MiddleCard;
    [SerializeField]
    private TextMeshProUGUI WinText;
    [SerializeField]
    private GameObject HowtoPlayPanel;

    #region WinLoose
    [SerializeField]
    private TextMeshProUGUI[] OppositeCard = new TextMeshProUGUI[2];
    [SerializeField]
    private GameObject OppPanel;
    [SerializeField]
    private TextMeshProUGUI StatusTxt;
    [SerializeField]
    private Button NextBtn; //계속하기
    [SerializeField]
    private Button ExplainBtn; //설명보기
    #endregion

    static public int IsCorrect = 0;//이긴 횟수
    static public int IsOpCorrect = 0;//상대가 이긴 횟수

    private int Stage=0;

    int nUserNum1, nUserNum2;
    int nBestAns;
    static public int nMidNum;
    static public int nOppositeNum;
    int nOppositeCard1;
    int nOppositeCard2;
    
    private int[] nCardUser = new int[8];
    private int[] nCardOpp = new int[8];
    private int[] nCard = new int[10];

    static public int UserClck;
    Vector3 Originpos;
    void Start()
    {
        IsCorrect = 0;
        IsOpCorrect = 0;
        Stage = 0;
        nUserNum1 = 0;
        nUserNum2 = 0;
        UserClck = 0;
        Originpos = CardDeck1.transform.localPosition;
        BindView();
    }

    public static int BlankNum1;
    public static int BlankNum2;
    static public void GetFirstNum(int num)
    {
        BlankNum1 = num;
    }
    static public void GetSecondNum(int num)
    {
        BlankNum2 = num;
    }
    void CalcNum()
    {
        if (BlankNum1 > 0 && BlankNum2 > 0)
        {
            int DragNum = Mathf.Abs( (BlankNum1 * BlankNum2) - GetUserCard.nMidNum);
            if (DragNum < nOppositeNum)
            {
                IsCorrect++;
                StatusTxt.text = "이겼습니다!";
            }
            else if ( DragNum == nOppositeNum)
            {
                IsCorrect++;
                IsOpCorrect++;
                StatusTxt.text = "비겼습니다!";
            }
            else
            {
                IsOpCorrect++;
                StatusTxt.text = "아쉬워요!";
            }
            NextStage();



        }
    }

    private void NextStage()
    {
        OppPanel.SetActive(true);   //상대방 패 공개

        Stage++;

        BlankNum1 = 0;
        BlankNum2 = 0;
    }
    public void ShowWin()
    {
        WinText.text = $"{IsCorrect}" + " / " + $"{IsOpCorrect}";
    }
    void CreateMiddleCard()
    {
        nMidNum = Random.Range(10, 82);
        MiddleCard.text = $"{nMidNum}";
    }

    void Opposite()
    {
        nBestAns = Mathf.Abs((nCardUser[0] * nCardUser[1]) - nMidNum);
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 8; j++)
            {
                int nCurNum = Mathf.Abs((nCardUser[i] * nCardUser[j]) - nMidNum);
                nBestAns = (nCurNum >= nBestAns) ? (nBestAns) : (nCurNum);
            }
        }
        nOppositeNum = Mathf.Abs((nCardUser[0] * nCardUser[1]) - nMidNum);
        nOppositeCard1 = nCardUser[0];
        nOppositeCard2 = nCardUser[1];
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 8; j++)
            {
                int nCurNum = Mathf.Abs((nCardOpp[i] * nCardOpp[j]) - nMidNum);
                if (nCurNum <= nBestAns)
                    continue;
                else if(nCurNum <= nOppositeNum)
                {
                    nOppositeNum = nCurNum;
                    nOppositeCard1 = nCardOpp[i];
                    nOppositeCard2 = nCardOpp[j];
                }
            }
        }
        //OppositeCard[0].text = $"{nOppositeCard1}";
        //OppositeCard[1].text = $"{nOppositeCard2}";
        OppositeCard[0].text = nOppositeCard1.ToString();
        OppositeCard[1].text = nOppositeCard2.ToString();

    }

    void CreateCardDeck()
    {

        for (int i = 0; i < 8; i++)
        {
            int num = Random.Range(2, 10);
            nCardUser[i] = num;
            nCard[num] += 1;
            if (nCard[num] > 2)
            {
                nCard[num] -= 1;
                i--;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            CardUser[i].text = $"{nCardUser[i]}";
            nCardOpp[i] = 11 - nCardUser[i];
        }
    }
    void BindView()
    {
        CardDeck1.OnClickAsObservable()
            .Subscribe(_ =>
            {
                UserClck = 1;
            })
                .AddTo(gameObject);

        CardDeck2.OnClickAsObservable()
            .Subscribe(_ =>
            {
                UserClck = 2;
            })
                .AddTo(gameObject);
        NextBtn.OnClickAsObservable()
            .Subscribe(_ =>
            {
                OppPanel.SetActive(false);
                InitPos();
                if (Stage == 6)
                    NextBtn.GetComponentInChildren<TextMeshProUGUI>().text = "결과보기";
                if (Stage == 7)
                {
                    ChangeCardStroy.TouchCnt = 6;
                    HowtoPlayPanel.SetActive(true);
                    return;
                }
                CreateMiddleCard();
                CreateCardDeck();
                Opposite();
            })
            .AddTo(gameObject);

    }

    void InitPos()
    {
        CollisionEvent.MiddleImage.transform.position = CDragenDrop.defpos1;
        CollisionEvent.EndImage.transform.position = CDragenDrop.defpos2;
        Debug.Log(CDragenDrop.nStage);
        Debug.Log(CDragenDrop.LCurStage);
    }

    void Update()
    {
        Vector3 Deck1position = CardDeck1.transform.localPosition;
        Vector3 Deck2position = CardDeck2.transform.localPosition;

        if(BlankNum1>0 && BlankNum2 > 0)
        {
            CalcNum();  
            ShowWin();

            BlankNum1 = 0;
            BlankNum2 = 0;

            for (int i = 0; i < 10; i++)
                nCard[i] = 0;
        }

        if (Mathf.Abs(Originpos.y - Deck1position.y) < 300 && UserClck<=4)
        {
            if (UserClck == 1)
            {
                Anounce.text = "";
                Deck1position.y -= 20;
                Deck2position.y += 15;
            }
            else if (UserClck == 2)
            {
                Anounce.text = "";
                Deck2position.y -= 20;
                Deck1position.y += 15;
            }
            CardDeck1.transform.localPosition = Deck1position;
            CardDeck2.transform.localPosition = Deck2position;
        }
        else if (UserClck > 0 && UserClck <= 2)
        {
            FirstMainPanel.SetActive(false);
            GamePanel.SetActive(true);

            CreateMiddleCard();
            CreateCardDeck();
            Opposite();
            UserClck = 3;
        }
        else if (UserClck == 3)
        {
            UserClck++;
        }
    }
}
