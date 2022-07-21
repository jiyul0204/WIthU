using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_RespawnManager : MonoBehaviour
{
    public static Runner_RespawnManager instance {get; private set;}
    public List <GameObject> MobPool = new List <GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;
    public int MobCnt = 0;
    public bool bGameEnd = false;
    void Awake()
    {
        instance = this;
       for(int i =0; i<Mobs.Length; i++)
        {
            for(int q = 0; q<objCnt; q++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform)); 
            }
        }
    }
    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
    
    IEnumerator CreateMob()
    {
        while(true)
        {
            if(bGameEnd == true)
                break;
            //Debug.Log(MobCnt);
            MobCnt++;
            
            if(MobCnt == 4)
            {
                Runner_GameManager.instance.isPlay = false;
                Runner_QPopupSystem.instance.OpenPopup();
            }


            MobPool[DeativeMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1.5f,4f)); // wait
        }
    }

    int DeativeMob()
    {
        List<int> num = new List<int>();
        for(int i=0; i<MobPool.Count;i++)
        {
            if(!MobPool[i].activeSelf)
                num.Add(i);
        }
        int x=0;
        if(num.Count > 0)
            x = num[Random.Range(0,num.Count)];
        return x;
    }
    
    void PlayGame(bool isplay)
    {
        if(isplay) // play버튼 누름
        {
            StartCoroutine(CreateMob());
            bGameEnd = false;
        }
        else
            StopAllCoroutines();
    }
    
    public void GameEnd()
    {
        bGameEnd = true;
    }

    public void Start()
    {
        StartCoroutine(CreateMob());
    }

    void PlayGame()
    {
        
    }

    void Update()
    {
         
    }
}
    /*public List<GameObject>MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 10;
    
    void Awake()
    {
        // 원하는 만큼 Mob을 생성해서 MobPool에 추가
        for(int i=0; i<Mobs.Length; i++)
        {
            for(int q=0; q<objCnt; q++)
                MobPool.Add(CreateObj(Mobs[i], transform));
        }
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj); // copy
        copy.transform.SetParent(parent); // Transform 자식으로 설정
        copy.SetActive(false); // 비활성화
        return copy;
    }

    IEnumerator CreateMob()
    {
        while(true)
        {
            MobPool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f,3f)); // Range 최소, 최대 사이만큼 Wait한 후 Mob생성
        }
    }

    int DeactiveMob()
    {
        List<int> num = new List<int>();
        for(int i=0; i<MobPool.Count; i++)
        {
            if(!MobPool[i].activeSelf)
                num.Add(i);
        }
        int x = 0;
        if(num.Count != 0)
        x = num[Random.Range(0, num.Count)];
        return x;
    }

    void Start()
    {
        StartCoroutine(CreateMob());    
    }

    void Update()
    {
        
    }*/

