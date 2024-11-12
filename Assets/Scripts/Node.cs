using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;
    public int Height;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
        Height = 1; 
    }
}
