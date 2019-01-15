using System;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast, all operations are constant time on average
    //
    // Con:
    //     Cache unfriendly, data is not in a single contiguous block
    //
    // Notes:
    //     Needs a good hash function/distribution of hash values
    //     Double in size when load factor is 1
    //     Reduce in half when load factor falls below 0.25
    //
    public sealed class HashSet<T>
    {
        private class Link
        {
            public T Key { get; set; }
            public Link Next { get; set; }
        }

        private Link[] _links;

        public HashSet()
        {
            _links = new Link[7];
        }

        public int Count { get; private set; }

        public int Buckets
        {
            get { return _links.Length; }
        }

        // O(1) average case, O(n) worst case  
        public bool Contains(T key)
        {
            return (GetKeyLink(key) != null);
        }

        // O(1) average case, O(n) worst case  
        public void Add(T key)
        {
            Link link = GetKeyLink(key);
            if (link != null)
                throw new ApplicationException("Key already present.");

            int index = KeyToIndex(key);

            link = new Link()
            {
                Key = key,
                Next = _links[index]
            };

            _links[index] = link;
            Count++;
            CheckForExpand();
        }

        // O(1) average case, O(n) worst case   
        public void Delete(T key)
        {
            int index = KeyToIndex(key);
            Link prev = null;
            Link link = _links[index];

            while (link != null)
            {
                if (link.Key.Equals(key))
                {
                    if (prev != null)
                        prev.Next = link.Next;
                    else
                        _links[index] = link.Next;

                    Count--;
                    CheckForShrink();
                    return;
                }

                prev = link;
                link = link.Next;
            }

            throw new ApplicationException("Key not found.");
        }

        private int KeyToIndex(T key)
        {
            return key.GetHashCode() % _links.Length;
        }

        private Link GetKeyLink(T key)
        {
            Link link = _links[KeyToIndex(key)];

            while (link != null)
            {
                if (link.Key.Equals(key))
                    return link;

                link = link.Next;
            }

            return null;
        }

        private void CheckForExpand()
        {
            // When we reach a load factor of 1 then expand
            if (Count > Buckets)
                Resize((Buckets * 2) + 1);
        }

        private void CheckForShrink()
        {
            // When we reach a load factor of 0.25 then shrink
            if ((Count >= 3) && (Count <= (Buckets / 4)))
                Resize(Buckets / 2);
        }

        private void Resize(int length)
        {
            Link[] old = _links;

            _links = new Link[length];
            Count = 0;

            // Put all keys into the new table
            for (int i = 0; i < old.Length; i++)
            {
                Link link = old[i];
                while (link != null)
                {
                    Add(link.Key);
                    link = link.Next;
                }
            }
        }
    }
}
