using System;
using System.Collections.Generic;

namespace FileWritingObjects
{
    public class NumSet
    {
        public LinkedList<int> Set;

        public NumSet(params int[] variable)
        {
            Set = new();
            foreach(int i in variable)
            {
                if (!Set.Contains(i))
                    Set.AddFirst(i);
            }
        }

        public override string ToString()
        {
            string res = "";
            foreach (int i in Set)
                res = res + i + " ";

            return res;
        }

        public static bool operator !=(NumSet set1, NumSet set2)
        {
            return !(set1 == set2);
        }

        public static bool operator ==(NumSet? set1, NumSet? set2)
        {
            if (set1 == null && set2 == null)
                return true;
            if (set1 == null || set2 == null)
                return false;

            return set1!.Equals(set2);
        }

        public bool Contains(int element)
        {
            return Set.Contains(element);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not NumSet numSet)
            {
                return false;
            }

            if (Set is null)
            {
                throw new ArgumentNullException(nameof(Set), "Set is null in Equals");
            }

            return this.Set == ((NumSet)obj).Set;
        }

        public override int GetHashCode()
        {
            if(Set == null)
                throw new ArgumentNullException(nameof(Set), "Set is null in GetHashCode");
            
            return Set.GetHashCode();
        }

        public int[] GetArray()
        {
            if (Set == null)
                throw new ArgumentNullException(nameof(Set), "Set is null in GetArray");

            int[] tempArray = new int[Set.Count];
            int i = 0;

            foreach (int set in Set)
                tempArray[i++] = set;

            return tempArray;
        }
    }
}
