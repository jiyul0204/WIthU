using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("M");
        // other : zone GameObject의 Collider2D Component만 인자로 넘어옴\
        if(other.tag =="Game")
        {
            SceneService.Instance.LoadScene(SceneName.GameMenu);
        }
        //if (other.tag == "Funiture")
        //{
        //    switch (other.gameObject.name)
        //    {
        //        case "Image(Left)":
        //            SceneService.Instance.LoadScene(GameName.Touch_Bell);
        //            break;
        //        case "Image(Right)":
        //            SceneService.Instance.LoadScene(GameName.CardGame);
        //            break;
        //    }
        //}
        //else
        //{
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
