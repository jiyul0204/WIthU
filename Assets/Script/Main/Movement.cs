using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Vector3 initMousePos;
    private Transform tr;
    Sprite RabbitMove;
    Sprite RabbitMoveInverse;

    static public int sec = 0;
    static public int secInverse = 0;
    private bool move = false;

    // joystick
    public MovePlayer movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    
    void FixedUpdate()
    {
        Debug.Log("player");
        if(movementJoystick.joystickVec.y != 0)
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        else
            rb.velocity = Vector2.zero;

        ScreenChk();
    }
    private void ScreenChk()
    {
        Debug.Log("player");
        Vector3 worldPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if(worldPos.x < 0.05f) worldPos.x = 0.05f;
        if(worldPos.x > 0.95f) worldPos.x = 0.95f;
        if(worldPos.y < 0.05f) worldPos.y = 0.05f;
        if(worldPos.y > 0.95f) worldPos.y = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }
    // Start is called before the first frame update

    public void Start()
    {
        Debug.Log("player");
        rb = GetComponent<Rigidbody2D>(); // joystick
        
        /*tr = GetComponent<Transform>();
        sec = 0;
        secInverse = 0;
        RabbitMove = Resources.Load("Norm", typeof(Sprite)) as Sprite;
        RabbitMoveInverse = Resources.Load("NormInverse", typeof(Sprite)) as Sprite;*/
    }

    public void Move()
    {
        sec++;
        if (sec == 1)
        {
            if (move == false)
                RabbitMove = Resources.Load("Left", typeof(Sprite)) as Sprite;
            else
                RabbitMove = Resources.Load("Right", typeof(Sprite)) as Sprite;
            move = !move;
        }
        else if (sec ==30)
        {
            RabbitMove = Resources.Load("Norm", typeof(Sprite)) as Sprite;
            sec = 0;
        }
        tr.GetComponent<Image>().sprite = RabbitMove;
    }

    void MoveInverse()
    {
        secInverse++;
        if (secInverse == 1)
        {
            if (move == false)
                RabbitMove = Resources.Load("LeftInverse", typeof(Sprite)) as Sprite;
            else
                RabbitMove = Resources.Load("RightInverse", typeof(Sprite)) as Sprite;
            move = !move;
        }
        else if (secInverse == 5)
        {
            RabbitMove = Resources.Load("NormInverse", typeof(Sprite)) as Sprite;
            secInverse = 0;
        }
        tr.GetComponent<Image>().sprite = RabbitMove;
    }
    // Update is called once per frame     
    public void Update()
    {
       /* // 마우스 클릭 및 터치했을때         
        if (Input.GetMouseButtonDown(0))
        {
            initMousePos = Input.mousePosition;
            initMousePos.z = 10;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
        }
        // 마우스 드래그시         
        if (Input.GetMouseButton(0))
        { 
            Vector3 movedPoint = Input.mousePosition;
            movedPoint.z = 10;
            movedPoint = Camera.main.ScreenToWorldPoint(movedPoint);
            Vector3 differencePos = movedPoint - initMousePos;
            if(differencePos.x<0)
                Move();
            else if (differencePos.x > 0)
                MoveInverse();
            differencePos.z = 0;
            initMousePos = Input.mousePosition;
            initMousePos.z = 10;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
            tr.transform.position =                
                new Vector3( Mathf.Clamp(tr.transform.position.x + differencePos.x, -9.5f, 9.5f),      
                Mathf.Clamp(tr.transform.position.y + differencePos.y, -4.0f, 4.0f),            
                tr.transform.position.z );
        }*/
    }
}
