using System.Runtime.InteropServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // private LineRenderer lr;
    // private Transform[] points;

    [SerializeField] List<Transform> nodes;
    LineRenderer lr;

    private void Start() {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = nodes.Count;
    }

    private void LateUpdate() {
        GenerateMeshCollider();
    }

    // public void SetUpLine(Transform[] points) {
    //     lr.positionCount = points.Length;
    //     this.points = points;
    // }

    private void Update() {
        // for (int i = 0; i < points.Length; i++)
        // {
        //     lr.SetPosition(i, points[i].position);
        // }
        lr.SetPositions(nodes.ConvertAll(n => n.position).ToArray());
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[lr.positionCount];
        lr.GetPositions(positions);
        return positions;
    }

    public float GetWidth()
    {
        return lr.startWidth;
    }

    public void GenerateMeshCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        lr.BakeMesh(mesh, Camera.main, true);
        collider.sharedMesh = mesh;
    }

    // public void GenerateEdgeCollider()
    // {
    //     EdgeCollider2D collider = GetComponent<EdgeCollider2D>();
    //     if (collider == null)
    //     {
    //         collider = gameObject.AddComponent<EdgeCollider2D>();
    //     }

    //     for (int i = 0; i < nodes.Count - 2; i++)
    //     {
    //         for (int j = 1; j < nodes.Count - 1; j++)
    //         {
    //             List<Vector2> myPoints = new List<Vector2>
    //             {
    //                 nodes[i].transform.position, 
    //                 nodes[j].transform.position
    //             };
    //             collider.SetPoints(myPoints);
    //         }
    //     }
    // }
}
