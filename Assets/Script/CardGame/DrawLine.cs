using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Camera cam;  //Gets Main Camera
    public Material defaultMaterial; //Material for Line Renderer

    private Vector3 PrevPos = Vector3.zero; // 0,0,0 position variable

    [SerializeField]
    GameObject DrawingPanel;


    void Start()
    {
        Debug.Log("Start");
    }
    //void connectLine(Vector3 mousePos)
    //{
    //    if (PrevPos != null && Mathf.Abs(Vector3.Distance(PrevPos, mousePos)) >= 0.001f)
    //    {
    //        PrevPos = mousePos;
    //        positionCount++;
    //        curLine.positionCount = positionCount;
    //        curLine.SetPosition(positionCount - 1, mousePos);
    //    }

    //}

    void DrawMouse()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
        if (!defaultMaterial)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            createLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 PrePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            createLine(mousePos);
        }
    }

    void createLine(Vector3 mousePos)
    {
        GL.PushMatrix();
        defaultMaterial.SetPass(0);
        GL.LoadPixelMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Vertex3(0,0,0);
        GL.Vertex3(mousePos.x, mousePos.y, 0);
        GL.End();
        GL.PopMatrix();


        //GameObject line = new GameObject("Line");
        //LineRenderer lineRend = line.AddComponent<LineRenderer>();

        //line.transform.parent = cam.transform;
        //line.transform.position = mousePos;

        //lineRend.startWidth = 0.01f;
        //lineRend.endWidth = 0.01f;
        //lineRend.numCornerVertices = 5;
        //lineRend.numCapVertices = 5;
        //lineRend.material = defaultMaterial;
        //lineRend.SetPosition(0, mousePos);
        //lineRend.SetPosition(1, mousePos);

        //curLine = lineRend;

    }
    // Update is called once per frame
    void Update()
    {
        DrawMouse();
    }
}
