using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineController), typeof(MeshCollider))]
public class LineCollision : MonoBehaviour
{
    // LineController lc;

    // // The collider for the line
    // PolygonCollider2D polygonCollider2D;

    // // The points to draw the collider
    // List<Vector2> colliderPoints = new List<Vector2>();

    // // Start is called before the first frame update
    // private void Awake()
    // {
    //     lc = GetComponent<LineController>();
    //     polygonCollider2D = GetComponent<PolygonCollider2D>();
    // }

    // private void LateUpdate()
    // {
    //     Vector3[] positions = lc.GetPositions();

    //     if (positions.Length >= 2)
    //     {
    //         int numberOfLines = positions.Length - 1;
    //         polygonCollider2D.pathCount = numberOfLines;

    //         for (int i = 0; i < numberOfLines; i++)
    //         {
    //             List<Vector2> currentPositions = new List<Vector2>
    //             {
    //                 positions[i],
    //                 positions[i+1]
    //             };

    //             List<Vector2> currentColliderPoints = CalculateColliderPoints(currentPositions);
    //             polygonCollider2D.SetPath(i, currentColliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
    //         }
    //     }
    //     else 
    //     {
    //         polygonCollider2D.pathCount = 0;
    //     }
    // }

    // private List<Vector2> CalculateColliderPoints(List<Vector2> positions)
    // {
    //     // Get Width
    //     float width = lc.GetWidth();

    //     // Gradient
    //     float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);

    //     float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
    //     float deltaY = (width / 2f) * (1 / Mathf.Pow(1 * m + m, 0.5f));

    //     // Calculate the offset from each point to the collision vertex
    //     Vector2[] offsets = new Vector2[2];
    //     offsets[0] = new Vector3(-deltaX, deltaY);
    //     offsets[1] = new Vector3(deltaX, -deltaY);

    //     // Generate the Colliders Vertices
    //     List<Vector2> colliderPoints = new List<Vector2> 
    //     {
    //         positions[0] + offsets[0],
    //         positions[1] + offsets[0],
    //         positions[1] + offsets[1],
    //         positions[0] + offsets[1]
    //     };

    //     return colliderPoints;
    // }
}
