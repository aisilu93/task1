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
            get
            {
                MyNode temp=root;
                for(int i=0;i<index-1;i++) { temp = temp.next; }
                return temp.elem;
            }
            set
            {
                MyNode temp=root;
                for(int i=0; i<index-1;i++) { temp=temp.next; }
                temp.elem=value;
            }
        }

        //
        // Summary:
        //     Gets or sets the element at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the element to get or set.
        //
        // Returns:
        //     The element at the specified index.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.Generic.IList`1.
        //
        //   T:System.NotSupportedException:
        //     The property is set and the System.Collections.Generic.IList`1 is read-only.
        T this[int index]
        {
            get
            {
                MyNode temp=root;
                for(int i=0;i<index-1;i++) { temp=temp.next; }
                return temp.elem;
            }
            set
            {
                MyNode temp=root;
                for(int i=0;i<index-1;i++) { temp=temp.next; }
                temp.elem=value;
            }
        }

        //
        // Summary:
        //     Determines the index of a specific item in the System.Collections.Generic.IList`1.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.IList`1.
        //
        // Returns:
        //     The index of item if found in the list; otherwise, -1.
        int IndexOf(T item)
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

        //
        // Summary:
        //     Inserts an item to the System.Collections.Generic.IList`1 at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index at which item should be inserted.
        //
        //   item:
        //     The object to insert into the System.Collections.Generic.IList`1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.Generic.IList`1.
        //
        //   T:System.NotSupportedException:
        //     The System.Collections.Generic.IList`1 is read-only.
        void Insert(int index,T item)
        {
            if(index>this.count) { throw new ArgumentOutOfRangeException(); }
            MyNode temp = root;
            MyNode new_item =new MyNode{elem = item};
            for(int i=0;i<index-1;i++) { temp=temp.next; }
            new_item.next = temp.next;
            temp.next = new_item;
            count++;
        }

        //
        // Summary:
        //     Removes the System.Collections.Generic.IList`1 item at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the item to remove.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.Generic.IList`1.
        //
        //   T:System.NotSupportedException:
        //     The System.Collections.Generic.IList`1 is read-only.
        void RemoveAt(int index)
        {
            if(index>this.count-1) { throw new ArgumentOutOfRangeException(); }
            MyNode temp=root;
            for(int i=0;i<index-2;i++) { temp=temp.next; }
            temp.next= temp.next.next;
            count--;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()   { return new Enumer(root); }
        IEnumerator IEnumerable.GetEnumerator()         { return new Enumer(root); }
        int IList<T>.IndexOf(T item)                    { return IndexOf(item); }
        void IList<T>.Insert(int index, T item)         { Insert(index, item); }
        void IList<T>.RemoveAt(int index)               { RemoveAt(index); }
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
            if (root.elem.Equals(item))
            {
                root = root.next;
                count--;
                return true;
            }
            MyNode current=root.next, prev=root;
            while (current != null)
            {
                if(current.elem.Equals(item))
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

        class MyNode
        {
            public T elem;
            public MyNode next;
        }

        class Enumer : IEnumerator<T>
        {
            MyNode current;
            public Enumer(MyNode root) { current = root; }
            public T Current => current.elem;
            object IEnumerator.Current => current.elem;
            public void Dispose(){}
            public bool MoveNext()
            {
                if (current.next == null) return false;
                current = current.next;
                return true;
            }
            public void Reset() { throw new NotImplementedException(); }
        }
    }
}
