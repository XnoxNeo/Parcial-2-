using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree
{
    public Node Root;
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private Node InsertRecursive(Node node, int value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRecursive(node.Right, value);
        }

        return node;
    }

    public List<int> InOrderTraversal(Node node)
    {
        List<int> result = new List<int>();
        if (node != null)
        {
            result.AddRange(InOrderTraversal(node.Left));
            result.Add(node.Value);
            result.AddRange(InOrderTraversal(node.Right));
        }
        return result;
    }

    public List<int> PreOrderTraversal(Node node)
    {
        List<int> result = new List<int>();
        if (node != null)
        {
            result.Add(node.Value);
            result.AddRange(PreOrderTraversal(node.Left));
            result.AddRange(PreOrderTraversal(node.Right));
        }
        return result;
    }

    public List<int> PostOrderTraversal(Node node)
    {
        List<int> result = new List<int>();
        if (node != null)
        {
            result.AddRange(PostOrderTraversal(node.Left));
            result.AddRange(PostOrderTraversal(node.Right));
            result.Add(node.Value);
        }
        return result;
    }

    public int MaxDepth(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftDepth = MaxDepth(node.Left);
        int rightDepth = MaxDepth(node.Right);

        return System.Math.Max(leftDepth, rightDepth) + 1;
    }

    public void InsertArray(int[] values)
    {
        foreach (int value in values)
        {
            Insert(value);
        }
    }
}
