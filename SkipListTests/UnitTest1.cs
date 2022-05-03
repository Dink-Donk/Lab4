using System;
using Xunit;
using SkipList2020;
using System.Collections.Generic;
using System.Linq;

namespace SkipListTests
{
    public class UnitTest1
    {
        [Fact]
        public void CountIncreaseAfterAdding()
        {
            int n = 10;
            var lib = new SkipList<int, int>();

            for(int i=0; i<n; i++)
            {
                lib.Add(i, i);
            }
            Assert.Equal(n, lib.Count);
        }
        [Fact]
        public void ItemsExistsAfterAdding()
        {
            var lib = new SkipList<int, int>();
            var nums = new List<int>(new[] { 44, 22, 1 , 56, 3, 90, 31, 15, 26 });
            int n = nums.Count;
            for (int i = 0; i < n; i++)
            {
                lib.Add(nums[i], i);
            }
            nums.Sort();
            int j = 0;
            foreach(var pair in lib)
            {
                Assert.Equal(nums[j], pair.Key);
                j++;
            }
            Assert.Equal(n, lib.Count);
        }

        [Fact]
        public void RandomItemsExistsAfterAdding()
        {
            var lib = new SkipList<int, int>();
            var nums = new HashSet<int>();
            var rd = new Random();
            int n = 100;
            while (nums.Count < n)
            {
                nums.Add(rd.Next(1, n * 3));
            }
            foreach(var item in nums)
            {
                lib.Add(item,1);
            }

            var a = nums.ToList();
            a.Sort();
            int j = 0;
            foreach (var pair in lib)
            {
                Assert.Equal(a[j], pair.Key);
                j++;
            }
            Assert.Equal(n, lib.Count);
        }

        [Theory]
        [InlineData(90)]
        [InlineData(1)]
        [InlineData(44)]
        public void ContainsFindsExistingElement(int keyToFind)
        {
            var lib = new SkipList<int, int>();
            var nums = new List<int>(new[] { 44, 22, 1, 56, 3, 90, 31, 15, 26 });
            int n = nums.Count;
            for (int i = 0; i < n; i++)
            {
                lib.Add(nums[i], i);
            }
            Assert.True(lib.Contains(keyToFind));
        }

        [Fact]
        public void ContainsDoesNotFindElement()
        {
            var lib = new SkipList<int, int>();
            var nums = new List<int>(new[] { 44, 22, 1, 56, 3, 90, 31, 15, 26 });
            int n = nums.Count;
            for (int i = 0; i < n; i++)
            {
                lib.Add(nums[i], i);
            }
            Assert.False(lib.Contains(-1));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(90)]
        [InlineData(56)]
        [InlineData(3)]
        public void ElementWasRemoved(int keyToRemove)
        {
            var lib = new SkipList<int, int>();
            var nums = new List<int>(new[] { 44, 22, 1, 56, 3, 90, 31, 15, 26 });
            int n = nums.Count;
            for (int i = 0; i < n; i++)
            {
                lib.Add(nums[i], i);
            }
            lib.Remove(keyToRemove);
            Assert.False(lib.Contains(keyToRemove));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(90)]
        [InlineData(56)]
        [InlineData(3)]
        public void RemoveRemovesOnlyOneElement(int keyToRemove)
        {
            var lib = new SkipList<int, int>();
            var nums = new List<int>(new[] { 44, 22, 1, 56, 3, 90, 31, 15, 26 });
            int n = nums.Count;
            for (int i = 0; i < n; i++)
            {
                lib.Add(nums[i], i);
            }
            lib.Remove(keyToRemove);
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == keyToRemove)
                    continue;
                Assert.True(lib.Contains(nums[i]));
            }
        }

        [Fact]
        public void RemoveDecreasesCount()
        {
            var lib = new SkipList<int, int>();
            var nums = new List<int>(new[] { 44, 22, 1, 56, 3, 90, 31, 15, 26 });
            int n = nums.Count;
            for (int i = 0; i < n; i++)
            {
                lib.Add(nums[i], i);
            }
            for (int i = 0; i < n; i++)
            {
                lib.Remove(nums[i]);
            }
            Assert.Equal(0, lib.Count);
        }
    }
}
