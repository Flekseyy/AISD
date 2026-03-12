namespace Task.CustomList;

    public class CustomList<T>: ICustomCollection<T>
    {
        protected Node<T> _firstNode;
        
        // Пустой список
        public CustomList()
        {
            _firstNode = null;
        }
        
        // Список из 1 элемента
        public CustomList(T value)
        {
            _firstNode = new Node<T>(value);
        }
        
        // Список из массива
        public CustomList(T[] values)
        {
            if (values == null || values.Length == 0)
            {
                _firstNode = null;
                return;
            }
        
            _firstNode = new Node<T>(values[0]);
            Node<T> tempNode = _firstNode;
        
            for (int i = 1; i < values.Length; i++)
            {
                tempNode.NextNode = new Node<T>(values[i]);
                tempNode = tempNode.NextNode;
            }
        }


        public virtual void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.NextNode = _firstNode;
            _firstNode = newNode;
        }

        public virtual void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (_firstNode == null)
            {
                _firstNode =  newNode;
                return;
            }
            Node<T> tempNode = _firstNode;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = newNode;
        }

        public virtual void AddInsert(int index, T value)
        {
            if (_firstNode == null)
            {
                if (index == 1)
                {
                    AddFirst(value);
                    return;
                }
                else
                {
                    Console.WriteLine("Список пуст!");
                    return;
                }
            }
            if (this.Size() + 1 < index || index < 1)
            {
                Console.WriteLine("Индекс выходит за границы");
                return;
            }
            
            Node<T> newNode = new Node<T>(value); 
            Node<T> tempNode = _firstNode;
            int count = 1;
            
            while (tempNode != null)
            {
                if (count == index - 1)
                {
                    newNode.NextNode = tempNode.NextNode;
                    tempNode.NextNode = newNode;
                    return;
                }
                count++;
                tempNode = tempNode.NextNode;
            }
        }

        public virtual void AddRange(T[]  values)
        {
            if (values == null ||  values.Length  == 0 )
            {
                Console.WriteLine("Список пуст");
                return;
            }
            foreach (T value in values)
            {
                AddLast(value);
            }
        }
        public virtual void Print()
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Список пустой!");
                return;
            }
            Node<T> tempNode = _firstNode;
            while (tempNode != null)
            {
                Console.Write($"{tempNode.Info} "+ (tempNode.NextNode==null?"":"-> "));
                tempNode = tempNode.NextNode;
                
            }
            Console.WriteLine();
        }
        
        public virtual void RemoveFirst()
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            _firstNode = _firstNode.NextNode;
        }

        public virtual void RemoveLast()
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            if (_firstNode.NextNode == null)
            {
                _firstNode = null;
                return;
            }
            Node<T> tempNode = _firstNode;
            while (tempNode.NextNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = null;
        }

        public virtual void RemoveAt(int index)
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (this.Size() < index || index < 1)
            {
                Console.WriteLine("Индекс выходит за границы");
                return;
            }
            if (index == 1)
            {
                RemoveFirst();
                return;
            }
      
            Node<T> tempNode = _firstNode;
            int count = 1;
            
            while (tempNode?.NextNode != null)
            {
                if (count == index - 1)
                {
                    tempNode.NextNode = tempNode.NextNode.NextNode;
                    return;
                }
                count++;
                tempNode = tempNode.NextNode;
            }
        }
        
        public virtual void RemoveSecond()
        {
            RemoveAt(2);  
        }
        
        public virtual void RemoveRange(int index)
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (this.Size() < index || index  < 1)
            {
                Console.WriteLine("Индекс выходит за границы");
                return;
            }

            if (index == 1)
            {
                _firstNode = null;
                return;
            }
            
            Node<T> tempNode = _firstNode;
            int pos = 1;
            
            while (tempNode.NextNode != null)
            {
                if (pos == index - 1 )
                {
                    tempNode.NextNode = null;
                    return;
                }
                tempNode = tempNode.NextNode;
                pos++;
            }
            
        }

        public virtual void RemoveAllOccurrences(T value)
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            List<int> indecs = new List<int>();
            int index = 1;
            Node<T> tempNode = _firstNode;
            
            while (tempNode != null)
            {
                if (Equals(tempNode.Info, value))
                {
                    indecs.Add(index);
                }
                tempNode = tempNode.NextNode;
                index++;
            }

            for (int i = indecs.Count - 1; i >= 0; i--)
            {
                RemoveAt(indecs[i]);
            }
        }
        

        public virtual void Reverse()
        {
            if (_firstNode == null) return;
            CustomList<T> tempList = new CustomList<T>();
            Node<T> tempNode = _firstNode;

            while (tempNode != null)
            {
                tempList.AddFirst(tempNode.Info);
                tempNode = tempNode.NextNode;
            }
            _firstNode = tempList._firstNode;
        }

        public virtual int Size()
        {
            int count  = 0;
            Node<T> tempNode = _firstNode;
            while (tempNode != null)
            {
                tempNode = tempNode.NextNode;
                count++;
            }
            return count;
        }
        
        public virtual bool IsEmpty()
        {
            return _firstNode == null;
        }

        public virtual bool Contains(T value)
        {
            Node<T> tempNode = _firstNode;
            while (tempNode != null)
            {
                if (Equals(tempNode.Info, value))
                {
                    return true;       
                }
                tempNode = tempNode.NextNode;
            }
            return false;
        }

        public virtual void FindAllIndices(T value)
        {
            Node<T> tempNode = _firstNode;
            int count = 1;
            while (tempNode != null)
            {
                if (Equals(tempNode.Info, value))
                {
                    Console.WriteLine($"Index {count} of {value}");  
                }
                tempNode = tempNode.NextNode;
                count++;
            }
        }
        
    }