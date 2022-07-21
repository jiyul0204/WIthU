using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
public class TouchBellService : MonoBehaviour
{
    private const int maxQuestionCount = 10;
    [SerializeField]
    private Button pauseButton; /// <�ٽ��ϱ�>

    [SerializeField]
    private Button SettingButton;/// <Pause��ư>

    [SerializeField]
    private Button homeButton;/// <��������>


    [SerializeField]
    private Button DelButton;

    [SerializeField]
    private GameObject restartPopupPanel;
    [SerializeField]
    private TextMeshProUGUI CurStatus;

    public static TouchBellService Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BindView();
        Reset();
    }

    private void BindView()
    {
        DelButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                restartPopupPanel.SetActive(!restartPopupPanel.activeSelf);
            })
                .AddTo(gameObject);

        SettingButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                restartPopupPanel.SetActive(true);
            })
                .AddTo(gameObject);

        homeButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SceneService.Instance.LoadScene(SceneName.Main);
            })
                .AddTo(gameObject);

        pauseButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Reset();
            })
                .AddTo(gameObject);
    }

    private void Reset()
    {
        Debug.Log("�ٽ��ϱ�");
        CreateCalc.ChangeNum(0);
        CurStatus.text = "����(0 / 10)";
        SliderTimer.fSliderBarTime = 81;
        restartPopupPanel.SetActive(false);
    }

}
