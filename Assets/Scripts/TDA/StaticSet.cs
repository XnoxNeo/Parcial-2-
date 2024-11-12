using System;
using System.Collections.Generic;

public class StaticSet<T> : ISet<T>
{
    private T[] elements;
    private int capacity;
    private int size;

    public StaticSet(int capacity)
    {
        this.capacity = capacity;
        elements = new T[capacity];
        size = 0;
    }

    public void Add(T element)
    {
        if (size < capacity && !Contains(element))
        {
            elements[size++] = element;
        }
    }

    public void Remove(T element)
    {
        for (int i = 0; i < size; i++)
        {
            if (EqualityComparer<T>.Default.Equals(elements[i], element))
            {
                elements[i] = elements[size - 1];
                size--;
                break;
            }
        }
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < size; i++)
        {
            if (EqualityComparer<T>.Default.Equals(elements[i], element))
            {
                return true;
            }
        }
        return false;
    }

    public List<T> GetElements()
    {
        List<T> result = new List<T>();
        for (int i = 0; i < size; i++)
        {
            result.Add(elements[i]);
        }
        return result;
    }

    public int Cardinality()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public ISet<T> Union(ISet<T> otherSet)
    {
        var resultSet = new StaticSet<T>(capacity + otherSet.Cardinality());
        foreach (var element in GetElements())
        {
            resultSet.Add(element);
        }
        foreach (var element in otherSet.GetElements())
        {
            resultSet.Add(element);
        }
        return resultSet;
    }

    public ISet<T> Intersect(ISet<T> otherSet)
    {
        var resultSet = new StaticSet<T>(capacity);
        foreach (var element in GetElements())
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
        var resultSet = new StaticSet<T>(capacity);
        foreach (var element in GetElements())
        {
            if (!otherSet.Contains(element))
            {
                resultSet.Add(element);
            }
        }
        return resultSet;
    }
}
