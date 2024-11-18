
namespace LeetCode.Task380
{
    public class RandomizedSet
    {
        private const int SIZE = 200000;

        private readonly Random _random;
        private readonly Dictionary<int, int> _itemsToIndexesMap;
        private readonly Dictionary<int, int> _indexesToItemsMap;

        public RandomizedSet()
        {
            _random = new Random();
            _itemsToIndexesMap = new Dictionary<int, int>(SIZE);
            _indexesToItemsMap = new Dictionary<int, int>(SIZE);
        }

        public bool Insert(int val)
        {
            if (_itemsToIndexesMap.TryGetValue(val, out _)) 
                return false;

            var newIndex = _indexesToItemsMap.Count;
            _itemsToIndexesMap.Add(val, newIndex);
            _indexesToItemsMap.Add(newIndex, val);

            return true;
        }

        public bool Remove(int val)
        {
            var targetItem = val;
            if (!_itemsToIndexesMap.TryGetValue(targetItem, out var indexOfTargetItem)) 
                return false;
            
            var indexOfLastItem = _indexesToItemsMap.Count - 1;
            var lastItem = _indexesToItemsMap[indexOfLastItem];

            _itemsToIndexesMap[lastItem] = indexOfTargetItem;
            _indexesToItemsMap[indexOfTargetItem] = lastItem;

            _indexesToItemsMap.Remove(indexOfLastItem);
            _itemsToIndexesMap.Remove(val);

            return true;
        }

        public int GetRandom()
        {
            var index = _random.Next(0, _indexesToItemsMap.Count);

            return _indexesToItemsMap[index];
        }
    }
}
