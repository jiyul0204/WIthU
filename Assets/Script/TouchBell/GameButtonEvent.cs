using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameButtonEvent : MonoBehaviour
{
    [SerializeField]
    Button DrawingDel;
    [SerializeField]
    GameObject DrawingPanel;

    [SerializeField]
    Button MemoButton;

    void Start()
    {
        BindView();
    }

    void BindView()
    {
        DrawingDel.OnClickAsObservable()
            .Subscribe(_ =>
            {
                DrawingPanel.SetActive(false);
            })
                .AddTo(gameObject);

        MemoButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                DrawingPanel.SetActive(true);
            })
                .AddTo(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
