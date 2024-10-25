namespace AllOne
{
    public class AllOne
    {
        private readonly Dictionary<string, long> _mapCount = new();
        private readonly Dictionary<long, HashSet<string>> _mapKeyBucket = new();
        private readonly SortedSet<long> _sortedSet = new();

        public void Inc(string key)
        {
            if (_mapCount.TryGetValue(key, out var count)) // existing
            {
                UpdateBucket(count, key, remove: true); 
                _mapCount[key] = ++count; 
            }
            else // New key
            {
                count = 1;
                _mapCount[key] = count;
            }

            UpdateBucket(count, key, remove: false); 
        }

        public void Dec(string key)
        {
            if (!_mapCount.TryGetValue(key, out var count)) return;

            UpdateBucket(count, key, remove: true); 
            if (--count == 0)
            {
                _mapCount.Remove(key); 
            }
            else
            {
                _mapCount[key] = count;
                UpdateBucket(count, key, remove: false); 
            }
        }

        public string GetMaxKey() => _sortedSet.Count == 0 ? "" : _mapKeyBucket[_sortedSet.Max].First();

        public string GetMinKey() => _sortedSet.Count == 0 ? "" : _mapKeyBucket[_sortedSet.Min].First();

        public void Inc(string[] keys) 
        {
            foreach (var key in keys) Inc(key);
        }

        private void UpdateBucket(long count, string key, bool remove)
        {
            if (remove)
            {
                if (!_mapKeyBucket.TryGetValue(count, out var bucket)) return;
                bucket.Remove(key);
                if (bucket.Count != 0) return;
                _mapKeyBucket.Remove(count);
                _sortedSet.Remove(count);
            }
            else
            {
                if (!_mapKeyBucket.TryGetValue(count, out var value))
                {
                    value = [];
                    _mapKeyBucket[count] = value;
                    _sortedSet.Add(count);
                }

                value.Add(key);
            }
        }

        public long Size() => _mapCount.Count;
    }
}
