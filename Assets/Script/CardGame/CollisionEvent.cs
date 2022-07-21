using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ZoneType
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
public class CollisionEvent : MonoBehaviour
{
    static public Image MiddleImage;
    static public Image EndImage;
    private void Start()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // other : zone GameObject의 Collider2D Component만 인자로 넘어옴
        if (other.tag == "Ans")
        {
            
            switch (other.gameObject.name)
            {
                case "Image(Blank)":
                    if (CDragenDrop.nStage == CDragenDrop.LCurStage)
                        return;
                    GetComponent<CDragenDrop>().GetCollisionComp(ZoneType.LEFT);
                    MiddleImage = this.GetComponent<Image>();
                    break;
                case "Image(Mid)":
                    if (CDragenDrop.nStage == CDragenDrop.RCurStage)
                        return;
                    GetComponent<CDragenDrop>().GetCollisionComp(ZoneType.RIGHT);
                    EndImage = this.GetComponent<Image>();
                    break;
            }
            //Debug.Log($"[KHW] object Name is {other.gameObject.name}");
        }
        else
        {
            CDragenDrop.IsCollision = 0;
        }
    }    
}
 
