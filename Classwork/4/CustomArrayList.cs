namespace Aisd._4;

public class CustomArrayList<T> where T:IComparable<T>
{
    private T[]? _info;
    private int _startIndex;
    private int _endIndex;

    public CustomArrayList(T someValue)
    {
        _info = [someValue];
    }

    public CustomArrayList(T[] someValue)
    {
        _info = someValue;
        _endIndex = someValue.Length - 1;
    }

    public void AddLast(T value)
    {
        if (_info == null)
        {
            _info = [value];
            return;
        }

        if (_endIndex < _info.Length - 1)
        {
            _info[_endIndex++] = value;
            return;
        }
        if (_startIndex > 0)
        {
            for (int i = _startIndex; i < _info.Length; i++)
            {
                _info[i - 1] = _info[i];
            }
            _startIndex--;
            _info[_endIndex++] = value;
            return;
        }
        var newInfo = new T[_endIndex + 2];
        for (int i = 0; i < _info.Length; i++)
        {
            newInfo[i] = _info[i];
        }
        _endIndex++;
        newInfo[_endIndex] = value;
        _info = newInfo;
    }

    public void AddFirst(T value)
    {
        if (_info == null)
        {
            _info = [value];
            return;
        }

        if (_startIndex > 0)
        {
            _info[--_startIndex] = value;
            return;
        }

        if (_endIndex < _info.Length - 1)
        {
            for (int i = _endIndex; i >= _startIndex; i--)
            {
                _info[i + 1] = _info[i];
            }
            _endIndex++;
            _info[_startIndex] = value;
            return;
        }
        var newInfo = new T[_info.Length + 2];
        
        for (int i = 1 ; i < _endIndex - _startIndex + 1; i++)
        {
            newInfo[i] = _info[i];
        }
        newInfo[_startIndex] = value;
        _info = newInfo;
        _endIndex++;
        return;
    }
    

    public void Insert(int index, T value)
    {
        
    }public void Print()
    {
        if (_info == null || _startIndex > _endIndex)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.Write("[");
        for (int i = _startIndex; i <= _endIndex; i++)
        {
            Console.Write(_info[i]);
            if (i < _endIndex)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
}