using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MODE
{
    EASY,
    NORMAL,
    HARD
}
public class SetMode : MonoBehaviour
{
    public MODE mode;
    static public MODE DecideMode(int nLevel)
    {
        if (nLevel < 25) return MODE.EASY;
        else if (nLevel < 50) return MODE.NORMAL;
        else if (nLevel < 75) return MODE.HARD;
        return MODE.EASY;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
