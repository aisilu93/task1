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
            MyNode temp=root;
            T a,b;
            for(int i=0;i<index-1;i++) { temp=temp.next; }
            a=temp.elem;
            temp.elem=item;
            temp=temp.next;
            while(temp.next!=null)
            {
                b=temp.elem;
                temp.elem=a;
                a=b;
            }
            MyNode last=new MyNode{ elem=a };
            temp.next=last;
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
            if(index>this.count) { throw new ArgumentOutOfRangeException(); }
            MyNode temp=root;
            for(int i=0;i<index-2;i++) { temp=temp.next; }
            temp.next= temp.next.next;
            count--;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IList<T>.IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
         class MyNode
        {
            public T elem;
            public MyNode next;
        }
    }
}
