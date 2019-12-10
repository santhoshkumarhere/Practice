using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.HashTable
{
    class HashNode<K, V>
    {
       public  K key;
       public  V value;

        public HashNode<K, V> next;

        public HashNode(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
    class Map<K, V>
    {

        private IList<HashNode<K, V>> bucketArray;

        // Current capacity of array list 
        private int numBuckets;

        // Current size of array list 
        private int size;

        public Map()
        {
            bucketArray = new List<HashNode<K, V>>();
            numBuckets = 10;
            size = 0;

            // Create empty chains 
            for (int i = 0; i < numBuckets; i++)
                bucketArray.Add(null);
        }

        public int Size() { return size; }
        public bool isEmpty() { return Size() == 0; }

        // This implements hash function to find index 
        // for a key 
        private int getBucketIndex(K key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % numBuckets;
            return index < 0 ? index * -1 : index;
        }

        // Method to remove a given key 
        public V remove(K key)
        {
            // Apply hash function to find index for given key 
            int bucketIndex = getBucketIndex(key);

            // Get head of chain 
            HashNode<K, V> head = bucketArray[bucketIndex];

            // Search for key in its chain 
            HashNode<K, V> prev = null;
            while (head != null)
            {
                // If Key found 
                if (head.key.Equals(key))
                    break;

                // Else keep moving in chain 
                prev = head;
                head = head.next;
            }

            // If key was not there 
            if (head == null)
                return default(V);

            // Reduce size 
            size--;

            // Remove key 
            if (prev != null)
                prev.next = head.next;
            else
                bucketArray[bucketIndex]= head.next;

            return head.value;
        }

        // Returns value for a key 
        public V get(K key)
        {
            // Find head of chain for given key 
            int bucketIndex = getBucketIndex(key);
            HashNode<K, V> head = bucketArray[bucketIndex];

            // Search key in chain 
            while (head != null)
            {
                if (head.key.Equals(key))
                    return head.value;
                head = head.next;
            }

            // If key not found 
            return default(V);
        }

        // Adds a key value pair to hash 
        public void add(K key, V value)
        {
            // Find head of chain for given key 
            int bucketIndex = getBucketIndex(key);
            HashNode<K, V> head = bucketArray[bucketIndex];

            // Check if key is already present 
            while (head != null)
            {
                if (head.key.Equals(key))
                {
                    head.value = value;
                    return;
                }
                head = head.next;
            }

            // Insert key in chain 
            size++;
            head = bucketArray[bucketIndex];
            HashNode<K, V> newNode = new HashNode<K, V>(key, value);
            newNode.next = head;
            bucketArray[bucketIndex] = newNode;

            // If load factor goes beyond threshold, then 
            // double hash table size 
            if ((1.0 * size) / numBuckets >= 0.7)
            {
                var temp = bucketArray;
                bucketArray = new List<HashNode<K, V>>();
                numBuckets = 2 * numBuckets;
                size = 0;
                for (int i = 0; i < numBuckets; i++)
                    bucketArray.Add(null);

                foreach (HashNode<K, V> x in temp)
                {
                    var headNode = x;
                    while (headNode != null)
                    {
                        add(headNode.key, headNode.value);
                        headNode = headNode.next;
                    }
                }
            }
        }

        public static void Test()
        {
           var map = new Map<string, int>();
            map.add("this", 1);
            map.add("coder", 2);
            map.add("this", 4);
            map.add("hello", 11);
            map.add("ji", 22);
            map.add("ij", 20);
            map.add("kumar", 11);
            map.add("santhosh", 5);
            map.add("ju", 8);
            map.add("hello", 6);
            map.add("hi", 5);
            Console.WriteLine(map.Size());
            Console.WriteLine(map.get("kumar"));
            Console.WriteLine(map.remove("this"));
            Console.WriteLine(map.remove("this"));
            Console.WriteLine(map.Size());
            Console.WriteLine(map.isEmpty());
        }
    }
}
