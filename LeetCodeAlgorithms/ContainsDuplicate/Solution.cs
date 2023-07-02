/*
    Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
*/

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var setOfNumbers = new HashSet<int>();

        foreach (var number in nums)
        {
            var wasElementAdded = setOfNumbers.Add(number);
            if (!wasElementAdded)
            {
                return true; // Contains duplicates
            }
        }
        return false; // Does not contain duplicates
    }
}

// Two-liner solution:
// var setOfNumbers = new HashSet<int>(nums);
// return setOfNumbers.Count != nums.Length;

// Also we can sort an array and check in loop if the current element is the same as the next one.

// Or we can make two nested loops and verify the duplicates via brute force.