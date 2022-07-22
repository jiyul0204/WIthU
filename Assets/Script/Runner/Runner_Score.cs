using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runner_Score : MonoBehaviour
{
    public static int nScore = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        nScore = 0;
    }

    void Update()
    {
        scoreText.text = nScore.ToString();
    }
}
