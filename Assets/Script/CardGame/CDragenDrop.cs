using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class CDragenDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //[SerializeField]
    //private Image[] Card = new Image[8];
    static public int nStage = 0;
    static public int WholeStage = 7;

    private TextMeshProUGUI SCriptTxt;

    private int FirstNum, SecondNum;

    public GameObject Invisiable_Zone1;
    public GameObject Invisiable_Zone2;
    private Vector3 invisdefaultposition1;
    private Vector3 invisdefaultposition2;
    private Vector3 defaultposition;

    static public Vector3 defpos1;
    static public Vector3 defpos2;

    public int[] Win = new int[WholeStage];
    static public int IsCollision;
    int IsCorrect;
    static public int LCurStage;
    static public int RCurStage;
    enum COLLISION
    {
        NONE,
        LEFT,
        RIGHT
    }
    private void Awake()
    {
        nStage = 0;
    }
    void Start()
    {
        nStage = 0;
        LCurStage = -1;
        RCurStage = -1;
        //invisdefaultposition1 = invisiable_zone1.transform.position;
        //invisdefaultposition2 = invisiable_zone2.transform.position;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //AudioManager.Inst.PlaySFX("C:\\Users\\KOREA\\Documents\\GitHub\\Math_Verse\\Assets\\Sound\\SFX\\collection_card_touch.wav");
        defaultposition = transform.position;  //처음 위치 저장
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = currentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (IsCollision == (int)COLLISION.NONE)
        {
            transform.position = defaultposition;
        }
        else
        {
            SCriptTxt = GetComponentInChildren<TextMeshProUGUI>();
            if (IsCollision==(int)COLLISION.LEFT)
            {
                if (nStage == LCurStage)
                    transform.position = defaultposition;
                else
                {
                    //AudioManager.Inst.PlaySFX(SoundType.CardGame_cardtouch.ToString());
                    LCurStage = nStage;
                    defpos1 = defaultposition;
                    transform.position = Invisiable_Zone1.transform.position;
                    FirstNum = int.Parse(SCriptTxt.text);
                    GetUserCard.GetFirstNum(FirstNum);
                }
            }
            else if(IsCollision==(int)COLLISION.RIGHT)
            {
                if (nStage == RCurStage)
                    transform.position = defaultposition;
                else
                {
                    //AudioManager.Inst.PlaySFX(SoundType.CardGame_cardtouch.ToString());
                    RCurStage = nStage;
                    defpos2 = defaultposition;
                    transform.position = Invisiable_Zone2.transform.position;
                    SecondNum = int.Parse(SCriptTxt.text);
                    GetUserCard.GetSecondNum(SecondNum);
                }
            }
        }
        if (GetUserCard.BlankNum1 > 0 && GetUserCard.BlankNum2 > 0)
            Destroy();

    }

    void Destroy()
    {
        Win[nStage++] = IsCorrect;
        IsCollision = (int)COLLISION.NONE;
        FirstNum = 0;
        IsCorrect = 0;
        SecondNum = 0;
    }

    public void GetCollisionComp(ZoneType type)
    {
        switch (type)
        {
            case ZoneType.LEFT:
                    IsCollision = (int)COLLISION.LEFT;
                break;
            case ZoneType.RIGHT:
                    IsCollision = (int)COLLISION.RIGHT;
                break;
        }
        
    }

}
