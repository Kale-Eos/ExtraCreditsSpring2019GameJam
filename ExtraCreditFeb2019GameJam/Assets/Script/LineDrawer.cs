using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    private GameObject lineGenerator;
    [SerializeField]
    private GameObject linePoint;
    public static bool Drawn;
  
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            CreatePointMarker(newPos);
        }

        if (Input.GetMouseButton(1))
        {
            ClearAllPoints();
        }

        if(Input.GetKeyDown("e"))
        {
            if(Drawn == false)
            {
                GenerateNewLine();
            }
            else
            {

            }
        }
    }

    private void GenerateNewLine()
    {
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");
        Vector3[] allPointPositions = new Vector3[allPoints.Length];

        if(allPoints.Length >= 2)
        {
            for (int i = 0; i < allPoints.Length; i++)
            {
                allPointPositions[i] = allPoints[i].transform.position;
            }

            SpawnLineGen(allPointPositions);
        }
        else
        {
            Debug.Log("Need 2 or more points to draw a line");
        }
    }

    private void Wait()
    {

    }

    private void CreatePointMarker(Vector3 pointPosition)
    {
        Instantiate(linePoint, pointPosition, Quaternion.identity);
    }

    private void ClearAllPoints()
    {
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");

        foreach (GameObject p in allPoints)
        {
            Destroy(p);
        }
    }

    private void SpawnLineGen(Vector3[] linePoints)
    {
        GameObject newLineGen = Instantiate(lineGenerator);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.positionCount = linePoints.Length;
        lRend.SetPositions(linePoints);

        Destroy(newLineGen, 2);
    }
}