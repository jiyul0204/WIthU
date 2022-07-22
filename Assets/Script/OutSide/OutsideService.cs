using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class OutsideService : MonoBehaviour
{
    [SerializeField]
    Button GoBackHome;
    void Start()
    {
        BindView();
    }

    void BindView()
    {
        GoBackHome.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SceneService.Instance.LoadScene(SceneName.Main);
            })
                .AddTo(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
