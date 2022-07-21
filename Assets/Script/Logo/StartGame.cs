using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class StartGame : MonoBehaviour
{

    public Button StartBtn;
    // Start is called before the first frame update
    void Start()
    {
        StartBtn.OnClickAsObservable()
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
