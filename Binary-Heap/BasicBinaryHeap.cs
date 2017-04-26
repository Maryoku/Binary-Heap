using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Heap
{
    class BasicBinaryHeap<T> where T: IComparable<T>
    {
        private List<T> Heap;

        public BasicBinaryHeap()
        {
            Heap = new List<T>();
        }

        public int HeapSize
        {
            get
            {
                return this.Heap.Count;
            }
        }

        public void Builder(params T[] values)
        {
            Heap = values.ToList();

            for (int i = Heap.Count / 2; i >= 0; i--)
            {
                Rebuild(i);
            }
        }
        
        public void Insert(T value)
        {
            if (Heap.Contains(value))
            {
                throw new ArgumentException("Элемент существует");
            }
            else
            {
                Heap.Add(value);
                for (int i = HeapSize / 2; i >= 0; i--)
                {
                    Rebuild(i);
                }
            }
        }

        public T Extract()
        {
            if (HeapSize == 0)
            {
                throw new ArgumentException("Не существует элементов для извлечения");
            }
            else
            {
                T root = Heap[0];
                Heap.RemoveAt(0);

                for (int i = HeapSize / 2; i >= 0; i--)
                {
                    Rebuild(i);
                }

                return root;
            }
        }

        public void Rebuild(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < HeapSize)
            {
                if ((Heap[left].CompareTo(Heap[largest]) > 0))
                    largest = left;
            }

            if (right < HeapSize)
            {
                if ((Heap[right].CompareTo(Heap[largest]) > 0))
                    largest = right;
            }

            if (largest != i)
            {
                T temp = Heap[largest];
                Heap[largest] = Heap[i];
                Heap[i] = temp;
                i = largest;
            }
        }
    }
}
