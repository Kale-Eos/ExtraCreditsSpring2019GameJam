using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EdgeCollider2D))]
public class BezierGenerator : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform point0, point1, point2, point3;

    private int numPoints = 50;
    private Vector3[] positions = new Vector3[50];

    void Start()
    {
        lineRenderer.positionCount = numPoints;
        DrawLinearCurve();
        DrawQuadraticCurve();
        DrawCubicCurve();
    }

    void Update()
    {
        //DrawQuadraticCurve();
        DrawCubicCurve();
    }

    public void DrawLinearCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalcLinearBezierPt(t, point0.position, point1.position);
        }
        lineRenderer.SetPositions(positions);
    }

    public void DrawQuadraticCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalcQuadraticBezierPt(t, point0.position, point1.position, point2.position);
        }
        lineRenderer.SetPositions(positions);
    }

    public void DrawCubicCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalcCubicBezierPt(t, point0.position, point1.position, point2.position, point3.position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalcLinearBezierPt(float t, Vector3 p0, Vector3 p1)
    {
        return p0 + t * (p1 - p0);
    }

    private Vector3 CalcQuadraticBezierPt(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        //(1-t)^2 P0 + 2(1-t)t P1 + t^2 P2

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }

    private Vector3 CalcCubicBezierPt(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // (1-t)^3 P0 +3(1-t)^2t P1 + 3(1-t) t^2 P2 + t3 P3

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;
        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;
        return p;
    }
}