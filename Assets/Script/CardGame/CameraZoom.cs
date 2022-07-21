using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private GameObject MainPanel;
    public Image BackGround;

    float Width;
    float Height;
    void Start()
    {
        Vector3 position = BackGround.transform.localPosition;
        Width = 1920;
        Height = 997.7f;

        position.x =0;
        position.y = 0;
        BackGround.transform.localPosition = position;
       
    }

    void Update()
    {
        if(Width<6400 && ChangeCardStroy.TouchCnt == 5)
        {
            Width+=60;
            Height+=5;
            BackGround.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Width);
            BackGround.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height);
        }
        else if(ChangeCardStroy.TouchCnt == 5 && GetUserCard.UserClck==0)
        {
            MainPanel.SetActive(true);
        }

    }

}
