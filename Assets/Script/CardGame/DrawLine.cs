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

    Camera mainCam { get { return Camera.main.GetComponent<Camera>(); } }
    bool mainCamFound { get { return mainCam != null; } }
    Ray ray { get {return mainCam.ScreenPointToRay(Input.mousePosition);} }
    RaycastHit hit;
    bool didHitSomething { get { return Physics.Raycast(ray, out hit); } }
    bool hitCollider { get { return hit.collider != null; } }

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
        linePrefab.SetActive(DrawingPanel.activeSelf);
        Line = GameObject.FindGameObjectsWithTag("Line");
        for (int i = 0; i < Line.Length; i++)
            Line[i].SetActive(DrawingPanel.activeSelf);
        if (DrawingPanel.activeSelf == true)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (didHitSomething && hitCollider)
                return;
            //if (position.x < -19.27 || position.x > -11.01f || position.y < -0.63f || position.y > 4.00f)
            //    return;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject go = Instantiate(linePrefab);
                lr = go.GetComponent<LineRenderer>();
                col = go.GetComponent<EdgeCollider2D>();
                points.Add(position);
                lr.positionCount = 1;
                lr.SetPosition(0, points[0]);
            }
            else if (Input.GetMouseButton(0))
            {
                points.Add(position);
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, position);
                col.points = points.ToArray();
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
