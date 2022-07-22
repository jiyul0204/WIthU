using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    LineRenderer lr;
    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();
    private Vector3 PrevPos = Vector3.zero; // 0,0,0 position variable
    private GameObject[] Line; 
    [SerializeField]
    GameObject DrawingPanel;
    [SerializeField]
    Button EraseButton;

    Vector3 pos;
    void Start()
    {
        BindView();
    }

    void Update()
    {
        LineRender();
    }
    

    void BindView()
    {
        EraseButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                for (int i = 0; i < Line.Length; i++)
                    Destroy(Line[i]);
            })
                .AddTo(gameObject);
    }
    void LineRender()
    {
        //Debug.Log(DrawingPanel.transform.position.);
        linePrefab.SetActive(DrawingPanel.activeSelf);
        Line = GameObject.FindGameObjectsWithTag("Line");
        for (int i = 0; i < Line.Length; i++)
            Line[i].SetActive(DrawingPanel.activeSelf);
        if (DrawingPanel.activeSelf==true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(position);
                if (position.x >= -9.34f &&  position.x <= -1.2f && pos.y >= -1.42 && pos.y <= 4.94)
                {
                    GameObject go = Instantiate(linePrefab);
                    lr = go.GetComponent<LineRenderer>();
                    col = go.GetComponent<EdgeCollider2D>();
                    points.Add(position);
                    lr.positionCount = 1;
                    lr.SetPosition(0, points[0]);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (pos.x >= -9.34f && pos.x <= -1.2f && pos.y >= -1.42 && pos.y <= 4.94)
                {
                    points.Add(pos);
                    lr.positionCount++;
                    lr.SetPosition(lr.positionCount - 1, pos);
                    col.points = points.ToArray();
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                points.Clear();
            }
        }
        else
        {
            Line = GameObject.FindGameObjectsWithTag("Line");
            for (int i = 0; i < Line.Length; i++)
                Line[i].SetActive(false);
        }
    }
}
