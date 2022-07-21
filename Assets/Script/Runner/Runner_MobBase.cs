using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_MobBase : MonoBehaviour
{
    public float fMobSpeed = 0;  
    
    public Vector2 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPosition; // 우측에서 시작하도록 셋팅
    }

    // Update is called once per frame
    void Update()
    {
            //tiles[i].transform.Translate(new Vector2(-2,0) * Time.deltaTime * Runner_GameManager.instance.gameSpeed);
       // transform.Translate(Vector2.left*Time.deltaTime*Runner_GameManager.instance.gameSpeed);
        
        if(Runner_GameManager.instance.isPlay)
            transform.Translate(new Vector2(-2,0)*Time.deltaTime*Runner_GameManager.instance.gameSpeed);
            
        if(transform.position.x<-10)
        {
            gameObject.SetActive(false); 
        }
    }
}
