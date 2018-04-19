using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_Test.Clases
{
    public class NativeMethodss<E> where E : IComparable
    {
        public void sortedInsert(E key, Object record, Node<E> N)
        {
            List<E> data = N.getKeys();
            List<Object> pointers = N.getPointers();
            if (data.Count == 0)
            {
                data.Add(key);
                pointers.Add(record);
                return;
            }
            else
            {
                if (key.CompareTo(data[0]) < 0)
                {
                    data.Insert(0, key);
                    pointers.Insert(0, record);
                }
                else
                {
                    Boolean flag = true;
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (key.CompareTo(data[i]) < 0)
                        {
                            flag = false;
                            data.Insert(i, key);
                            pointers.Insert(i, record);
                            break;
                        }
                    }
                    if (flag)
                    {
                        data.Add(key);
                        pointers.Add(record);
                    }
                }
            }
        }

        public void sortedInsertInternal(E key, Object record, Node<E> N)
        {
            List<E> data = N.getKeys();
            List<Object> pointers = N.getPointers();
            if (key.CompareTo(data[0]) < 0)
            {
                data.Insert(0, key);
                pointers.Insert(1, record);
            }
            else
            {
                Boolean flag = true;
                for (int i = 0; i < data.Count; i++)
                {
                    if (key.CompareTo(data[i]) < 0)
                    {
                        data.Insert(i, key);
                        pointers.Insert(i + 1, record);
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    data.Add(key);
                    pointers.Add(record);
                }
            }
        }
        public void deleteNode(Node<E> n, E k)
        {
            for (int i = 0; i < n.getKeys().Count; i++)
            {
                if (k.CompareTo(n.getKeys()[i]) == 0)
                {
                    n.getKeys().RemoveAt(i);
                    n.getPointers().RemoveAt(i);
                }
            }
        }
        public void internalDelet(E key, Node<E> n, Node<E> temp)
        {
            for (int i = 0; i < n.getKeys().Count; i++)
            {
                if (n.getKeys()[i].CompareTo(key) == 0)
                {
                    n.getKeys().RemoveAt(i);
                    n.getPointers().RemoveAt(i + 1);
                }
            }
        }

        public int sameParent(Node<E> n, Node<E> parent, int size)
        {
            List<E> keys = parent.getKeys();
            Boolean _next = false;
            Boolean _prev = false;
            Node<E> next = n.getNext();
            Node<E> prev = n.getPrev();
            if (sameParent2(parent, n))
            {
                for (int i = 0; i < parent.getPointers().Count; i++)
                {
                    if (next == parent.getPointers()[i])
                    {
                        _next = true;
                        break;
                    }
                }
            }
            if (!sameParent2(parent, n))
            {
                for (int i = 0; i < parent.getPointers().Count; i++)
                {
                    if (prev == parent.getPointers()[i])
                    {
                        _prev = true;
                        break;
                    }
                }
            }
            if (_next && next.getKeys().Count - 1 >= Math.Ceiling(size / 2.0))
            {
                return 1;
            }
            else if (_prev && next.getKeys().Count - 1 >= Math.Ceiling(size / 2.0))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        public Boolean sameParent2(Node<E> parent, Node<E> n)
        {
            Boolean _next = false;
            Boolean _prev = false;
            Node<E> next = n.getNext();
            Node<E> prev = n.getPrev();
            if (next != null)
            {
                for (int i = 0; i < parent.getPointers().Count; i++)
                {
                    if (next == parent.getPointers()[i])
                    {
                        _next = true;
                        break;
                    }
                }
            }
            if (prev != null)
            {
                for (int i = 0; i < parent.getPointers().Count; i++)
                {
                    if (prev == parent.getPointers()[i])
                    {
                        _prev = true;
                        break;
                    }
                }
            }
            if (_next)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int nexOrprev(Node<E> n, Node<E> parent, int size)
        {

            Boolean _next = false;
            Boolean _prev = false;
            Node<E> next = n.getNext();
            Node<E> prev = n.getPrev();
            if (next != null)
            {
                for (int i = 0; i < parent.getPointers().Count; i++)
                {
                    if (next == parent.getPointers()[i])
                    {
                        _next = true;
                        break;
                    }
                }
            }
            if (prev != null)
            {
                for (int i = 0; i < parent.getPointers().Count; i++)
                {
                    if (prev == parent.getPointers()[i])
                    {
                        _prev = true;
                        break;
                    }
                }
            }
            if (next != null && _next && next.getKeys().Count - 1 >= 1)
            {
                return 1;
            }
            else if (prev != null && _prev && prev.getKeys().Count - 1 >= 1)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}