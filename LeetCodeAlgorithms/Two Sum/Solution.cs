/*
    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

    You may assume that each input would have exactly one solution, and you may not use the same element twice.

    You can return the answer in any order.

    Example:
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
*/

// Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var alreadySeenElements = new Dictionary<int, int>(); // Value:Index map (If we use Index:Value, then we have to use FirstOrDefault 
        // or some other lookup to get key by value, because values do not necessarily have to be unique)

        for (int i = 0; i < nums.Length; i++)
        {
            if (alreadySeenElements.ContainsKey(target-nums[i])) // Key contains value
            {
                return new int[] { i, alreadySeenElements[target-nums[i]] };
            }

            // Otherwise add our value to the dictionary and continue
            // If we've already seen this value we can ignore it since both indexes would be valid.
            if (!alreadySeenElements.ContainsKey(nums[i]))
            {
                alreadySeenElements.Add(nums[i], i);
            }
        }

        return null;
    }
}

// Also we can use two nested loops and use brute force to find the elements. n^2 time complexity, but O(1) memory complexity
/*
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = 1; j < nums.Length; j++)
            {
                if (target - nums[i] == nums[j])
                {
                    return new int[] { i, j };
                }
            }
        }
        return new int[0];
    }
}
*/