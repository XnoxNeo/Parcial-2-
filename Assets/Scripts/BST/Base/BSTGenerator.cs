using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BSTGenerator : MonoBehaviour
{
    public BinarySearchTree tree;
    public GameObject nodePrefab;

    public Material lineMaterial;

    private void Start()
    {
        int[] myArray = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };
        //int[] myArray2 = { 12,2,3,212,35,32,312,23,65,4,6,9 };
        tree = new BinarySearchTree();
        tree.InsertArray(myArray);
        //tree.InsertArray(myArray2);

        VisualizeTree(tree.Root, Vector3.zero, 5);

        Debug.Log("InOrder: " + string.Join(", ", tree.InOrderTraversal(tree.Root)));
        Debug.Log("PreOrder: " + string.Join(", ", tree.PreOrderTraversal(tree.Root)));
        Debug.Log("PostOrder: " + string.Join(", ", tree.PostOrderTraversal(tree.Root)));
        Debug.Log("Max Depth: " + tree.MaxDepth(tree.Root));
    }

    private void VisualizeTree(Node node, Vector3 position, float offset)
    {
        if (node == null) return;

        GameObject nodeObject = Instantiate(nodePrefab, position, Quaternion.identity);
        nodeObject.GetComponentInChildren<TMP_Text>().text = node.Value.ToString();

        if (node.Left != null)
        {
            Vector3 leftPosition = position + new Vector3(-offset, -2, 0);
            VisualizeTree(node.Left, leftPosition, offset / 2);
            CreateConnectionLine(position, leftPosition);
        }

        if (node.Right != null)
        {
            Vector3 rightPosition = position + new Vector3(offset, -2, 0);
            VisualizeTree(node.Right, rightPosition, offset / 2);
            CreateConnectionLine(position, rightPosition);
        }
    }

    private void CreateConnectionLine(Vector3 start, Vector3 end)
    {
        GameObject lineObject = new GameObject("ConnectionLine");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        lineRenderer.material = lineMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }
}
