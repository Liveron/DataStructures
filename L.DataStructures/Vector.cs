using System.Collections;

namespace L.DataStructures;

public class Vector<T> : IEnumerable<T>
{
    private readonly int _defautlCapacity = 4;

    private T[] _values;
    public int Length { get; private set; }
    public int Capacity => _values.Length;

    public Vector()
    {
        _values = new T[_defautlCapacity];
        Length = 0;
    }

    public Vector(int capacity)
    {
        _values = new T[capacity];
        Length = 0;
    }

    public Vector(IEnumerable<T> values)
    {
        if (values.GetEnumerator().MoveNext())
        {
            _values = [.. values];
            Length = _values.Length;
        }
        else
        {
            _values = new T[_defautlCapacity];
            Length = 0;
        }
    }

    public T this[int index]
    {
        get => Get(index);
        set => Set(index, value);
    }

    // O(1)
    private T Get(int index) => _values[index];

    // O(1)
    private void Set(int index, T value)
    {
        if (index < 0 || index >= Length)
            throw new ArgumentOutOfRangeException(nameof(index));

        _values[index] = value;
    }

    // O*(1)
    public void Add(T value)
    {
        if (Capacity <= Length)
            Increase();
        
        _values[Length++] = value;
    }

    // O(n)
    private void Increase()
    {
        var newValues = new T[Capacity * 2];
        Array.Copy(_values, newValues, Length);
        _values = newValues;
    }

    // O*(1)
    public T Remove()
    {
        if (Length <= 0)
            throw new InvalidOperationException("There are no elements to remove.");

        if (Length == 1)
            return _values[0];

        if (Capacity / Length - 1 >= 4)
            Decrease();

        return _values[--Length];
    }

    // O(n)
    private void Decrease()
    {
        var newValues = new T[Capacity / 2];
        Array.Copy(_values, newValues, Length);
        _values = newValues;
    }

    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_values).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
}
