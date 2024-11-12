using System;
using System.Collections.Generic;

public class DynamicSet<T> : ISet<T>
{
    private List<T> elements;

    public DynamicSet()
    {
        elements = new List<T>();
    }

    public void Add(T element)
    {
        if (!elements.Contains(element))
        {
            elements.Add(element);
        }
    }

    public void Remove(T element)
    {
        elements.Remove(element);
    }

    public bool Contains(T element)
    {
        return elements.Contains(element);
    }

    public List<T> GetElements()
    {
        return elements;
    }

    public int Cardinality()
    {
        return elements.Count;
    }

    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public ISet<T> Union(ISet<T> otherSet)
    {
        var resultSet = new DynamicSet<T>();
        resultSet.AddRange(elements);
        foreach (var element in otherSet.GetElements())
        {
            resultSet.Add(element);
        }
        return resultSet;
    }

    public ISet<T> Intersect(ISet<T> otherSet)
    {
        var resultSet = new DynamicSet<T>();
        foreach (var element in elements)
        {
            if (otherSet.Contains(element))
            {
                resultSet.Add(element);
            }
        }
        return resultSet;
    }

    public ISet<T> Difference(ISet<T> otherSet)
    {
        var resultSet = new DynamicSet<T>();
        foreach (var element in elements)
        {
            if (!otherSet.Contains(element))
            {
                resultSet.Add(element);
            }
        }
        return resultSet;
    }

    private void AddRange(List<T> range)
    {
        foreach (var element in range)
        {
            Add(element);
        }
    }
}

