using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVLTree : BinarySearchTree
{
    public new void Insert(int value)
    {
        Root = InsertAVL(Root, value);
    }

    private Node InsertAVL(Node node, int value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertAVL(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertAVL(node.Right, value);
        }
        else
        {
            return node;
        }

        node.Height = 1 + Mathf.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balance = GetBalance(node);

        if (balance > 1 && value < node.Left.Value)
        {
            return RotateRight(node);
        }

        if (balance < -1 && value > node.Right.Value)
        {
            return RotateLeft(node);
        }

        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }
        return node;
    }

    private Node RotateRight(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Mathf.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Mathf.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private Node RotateLeft(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Mathf.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Mathf.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y; 
    }

    private int GetHeight(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Height;
    }

    private int GetBalance(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    public new void InsertArray(int[] values)
    {
        foreach (int value in values)
        {
            Insert(value);
        }
    }
}
