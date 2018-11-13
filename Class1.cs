using System;
using System.Collections;
using System.Collections.Generic;

namespace task1
{
    public class MyList<T>: IEnumerable<T>, IList<T>
    {
        MyNode root;
        int count;

        public int Count { get => count; }
        public bool IsReadOnly { get => false; }
        T IList<T>.this[int index]
        {
            get { return getElem(index).elem; }
            set { getElem(index).elem = value; }
        }
        T this[int index]
        {
            get { return getElem(index).elem; }
            set { getElem(index).elem=value; }
        }
        private MyNode getElem(int index)
        {
            MyNode temp = root;
            for (int i=0; i<index-1; i++) { temp = temp.next; }
            return temp;
        }
        public int IndexOf(T item)
        {
            MyNode temp=root;
            int index=0;
            while(temp.next!=null)
            {
                if(temp.elem.Equals(item)) return index;
                index++;
                temp=temp.next;
            }
            return -1;
        }
        public void Insert(int index,T item)
        {
            if(index>this.count) { throw new ArgumentOutOfRangeException(); }
            if(count == 0) { root = new MyNode { elem=item }; count++; return; }
            MyNode temp = root;
            MyNode new_item = new MyNode{elem = item};
            temp = getElem(index);
            new_item.next = temp.next;
            temp.next = new_item;
            count++;
        }
        public void RemoveAt(int index)
        {
            if(index>this.count-1) { throw new ArgumentOutOfRangeException(); }
            if (index == 0) { root = root.next; return; }
            MyNode temp=root;
            for(int i=1;i<index-2;i++) { temp=temp.next; }
            temp.next= temp.next.next;
            count--;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()   { return new Enumer(root); }
        IEnumerator IEnumerable.GetEnumerator()         { return new Enumer(root); }
        public void Add(T item)                         { Insert(count, item); }
        public void Clear()                             { root = null; count = 0; }
        public bool Contains(T item)                    { return IndexOf(item) != -1; }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if(arrayIndex<0) throw new ArgumentOutOfRangeException();
            if(array.Length-arrayIndex<count) throw new ArgumentException();
            MyNode temp=root;
            for(int i=arrayIndex; i<array.Length; i++)
            {
                array[i]=temp.elem;
                if(temp.next==null) break;
                temp=temp.next;
            }
        }

        public bool Remove(T item)
        {
            if (root==null) return false;
            if (root.elem.Equals(item))
            {
                root = root.next;
                count--;
                return true;
            }
            MyNode current = root.next, prev = root;
            while (current != null)
            {
                if (current.elem.Equals(item))
                {
                    prev.next = current.next;
                    count--;
                    return true;
                }
                prev = current;
                current = current.next;
            }
            return false;
        }
        public override string ToString()
        {
            String res = "";
            if (count==0) return res;
            foreach (T a in this)
            {
                res=res.Insert(res.Length, a.ToString());
            }
            return res;
        }

        class MyNode
        {
            public T elem;
            public MyNode next;
        }

        class Enumer : IEnumerator<T>
        {
            MyNode current;
            MyNode root;
            public Enumer(MyNode root) { current = null; this.root = root; }
            public T Current => current.elem;
            object IEnumerator.Current => current.elem;
            public void Dispose(){}
            public bool MoveNext()
            {
                if (current == null) { current = root; return true; }
                if (current.next == null) return false;
                current = current.next;
                return true;
            }
            public void Reset() { current = null; }
        }
    }
}
