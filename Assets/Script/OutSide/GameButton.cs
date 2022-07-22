using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
public class GameButton : MonoBehaviour
{
    [SerializeField]
    Button Log;
    [SerializeField]
    Button Run;
    [SerializeField]
    Button Card;
    void Start()
    {
        BindView();
    }

    void BindView()
    {
        Log.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SceneService.Instance.LoadScene(GameName.Touch_Bell);
            })
                .AddTo(gameObject);

        Run.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SceneService.Instance.LoadScene(GameName.G_Runner);
            })
                .AddTo(gameObject);

        Card.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SceneService.Instance.LoadScene(GameName.CardGame);
            })
                .AddTo(gameObject);
    }
}
