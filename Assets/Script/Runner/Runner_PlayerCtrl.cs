using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_PlayerCtrl : MonoBehaviour
{
    bool isJump = false;
    bool isTop = false;

    public float jumpHeight = 0;
    public float jumpSpeed = 0;
    
    Vector2 startPosition;
    Animator animator;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mob"))
        {
            RunnerGameManager.instance.GameOver();
        }
    }*/

    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(Runner_GameManager.instance.isPlay == true)
            animator.SetBool("run", true);

        if(Input.GetMouseButtonDown(0) && Runner_GameManager.instance.isPlay)
        {
            isJump = true;
        }
        else if(transform.position.y <= startPosition.y)
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }

        if(isJump)
        {
            if(transform.position.y <= jumpHeight - 0.1f && !isTop)
            {
                transform.position = Vector2.Lerp(transform.position, 
                    new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }
            if(transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition,jumpSpeed*Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mob"))
        {
            Runner_GameManager.instance.GameOver();
        }
    }
}
