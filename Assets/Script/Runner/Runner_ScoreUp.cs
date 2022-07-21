using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_ScoreUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Runner_Score.nScore++;
    }
}
