namespace Task.CustomArrayList;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[]? _info;
    private int _startIndex;
    private int _endIndex;

    public CustomArrayList()
    {
        _info = null;
        _startIndex = 0;
        _endIndex = 0;
    }

    public CustomArrayList(T someValue)
    {
        _info = new T[] { someValue };
        _startIndex = 0;
        _endIndex = 0;
    }

    public CustomArrayList(T[] someValue)
    {
        _info = someValue;
        _startIndex = 0;
        _endIndex = someValue.Length - 1;
    }

    public void AddLast(T value)
    {
        if (_info == null)
        {
            _info = new T[] { value };
            return;
        }

        if (_endIndex < _info.Length - 1)
        {
            _info[++_endIndex] = value;
            return;
        }

        int count = _endIndex - _startIndex + 1;
        var newInfo = new T[_info.Length * 2];
        for (int i = 0; i < count; i++)
        {
            newInfo[i] = _info[_startIndex + i];
        }
        _info = newInfo;
        _endIndex = count;
        _info[_endIndex] = value;
        _startIndex = 0;
    }

    public void AddFirst(T value)
    {
        if (_info == null)
        {
            _info = new T[] { value };
            return;
        }

        if (_startIndex > 0)
        {
            _info[--_startIndex] = value;
            return;
        }

        int count = _endIndex - _startIndex + 1;
        var newInfo = new T[_info.Length * 2];
        for (int i = 0; i < count; i++)
        {
            newInfo[i + 1] = _info[_startIndex + i];
        }
        _info = newInfo;
        _startIndex = 0;
        _endIndex = count;
        _info[_startIndex] = value;
    }

    public void Insert(T value, int index)
    {
        if (_info == null)
        {
            _info = new T[] { value };
            return;
        }

        int count = _endIndex - _startIndex + 1;

        if (index < 0 || index > count)
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        if (index == 0)
        {
            AddFirst(value);
            return;
        }

        if (index == count)
        {
            AddLast(value);
            return;
        }

        if (count < _info.Length)
        {
            int realIndex = _startIndex + index;
            
            for (int i = _endIndex; i >= realIndex; i--)
            {
                _info[i + 1] = _info[i];
            }
            
            _info[realIndex] = value;
            _endIndex++;
        }
        else
        {
            var newInfo = new T[_info.Length * 2];
            
            for (int i = 0; i < index; i++)
            {
                newInfo[i] = _info[_startIndex + i];
            }
            newInfo[index] = value;
            for (int i = 0; i < count - index; i++)
            {
                newInfo[index + 1 + i] = _info[_startIndex + index + i];
            }
            
            _info = newInfo;
            _startIndex = 0;
            _endIndex = _endIndex - _startIndex + 1;
        }
    }

    public void RemoveAt(int index)
    {
        if (_info == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        int count = _endIndex - _startIndex + 1;

        if (index < 0 || index >= count)
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        int realIndex = _startIndex + index;

        if (index == 0)
        {
            _startIndex++;
            if (_startIndex > _endIndex)
            {
                _info = null;
                _startIndex = 0;
                _endIndex = 0;
            }
            return;
        }

        if (index == count - 1)
        {
            _endIndex--;
            if (_startIndex > _endIndex)
            {
                _info = null;
                _startIndex = 0;
                _endIndex = 0;
            }
            return;
        }

        for (int i = realIndex; i < _endIndex; i++)
        {
            _info[i] = _info[i + 1];
        }
        
        _endIndex--;
    }

    public void RemoveRange(int index)
    {
        if (_info == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        int count = _endIndex - _startIndex + 1;

        if (index < 0 || index >= count)
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        if (index == 0)
        {
            _info = null;
            _startIndex = 0;
            _endIndex = 0;
            return;
        }

        int realIndex = _startIndex + index;
        _endIndex = realIndex - 1;
    }

    public void Reverse()
    {
        if (_info == null)
            return;

        int left = _startIndex;
        int right = _endIndex;

        while (left < right)
        {
            (_info[left], _info[right]) = (_info[right], _info[left]);
            left++;
            right--;
        }
    }

    public void Print()
    {
        if (_info == null)
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