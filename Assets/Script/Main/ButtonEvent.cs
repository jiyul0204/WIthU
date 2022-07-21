using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class ButtonEvent : MonoBehaviour
{
    [SerializeField]
    Button StatusButton;
    [SerializeField]
    Button UserButton;
    [SerializeField]
    Button Del;
    [SerializeField]
    Button DrawerButton;
    [SerializeField]
    GameObject StatusPanel;
    [SerializeField]
    GameObject DrawerPanel;
    void Start()
    {
        BindView();
    }

    void BindView()
    {
        StatusButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                StatusPanel.SetActive(!StatusPanel.activeSelf);
            })
                .AddTo(gameObject);

        Del.OnClickAsObservable()
            .Subscribe(_ =>
            {
                DrawerPanel.SetActive(false);
            })
                .AddTo(gameObject);
        
        
        
        
        
        
        DrawerButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                DrawerPanel.SetActive(true);
            })
                .AddTo(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
