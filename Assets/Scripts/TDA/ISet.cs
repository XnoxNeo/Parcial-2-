using System.Collections.Generic;

public interface ISet<T>
{
    void Add(T element);
    void Remove(T element);
    bool Contains(T element);
    List<T> GetElements();
    int Cardinality();
    bool IsEmpty();
    ISet<T> Union(ISet<T> otherSet);
    ISet<T> Intersect(ISet<T> otherSet);
    ISet<T> Difference(ISet<T> otherSet);
}
