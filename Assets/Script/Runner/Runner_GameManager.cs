using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runner_GameManager : MonoBehaviour
{
    #region instance
    public static Runner_GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    
    public delegate void OnPlay(bool isPlay);
    public OnPlay onPlay;

    public float gameSpeed = 1f; // 장애물과 캐릭터의 속도 조절
    public bool isPlay = false;
    public GameObject playBtn;

    public void PlayBtnClick()
    {
        playBtn.SetActive(false);
        isPlay = true;
        //onPlay.Invoke(isPlay);
    }

    public void GameEnd()
    {
        isPlay = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        /*if((Runner_RespawnManager.instance.MobCnt > 1) && (Runner_RespawnManager.instance.MobCnt % 8 == 0) && bSet == false)
        //if(Runner_RespawnManager.instance.MobCnt % 8 == 0)
        {
            bSet = true;
            isPlay = false;
            Debug.Log("here");
            Runner_QPopupSystem.instance.OpenPopup();
        }
        else
            bSet = false;*/
    }
    
    public void GameOver() // 장애물에 부딪혔을 때
    {
        Runner_Score.nScore--;
        //playBtn.SetActive(true);
        //isPlay = false;

        //onPlay.Invoke(isPlay);
    }
}