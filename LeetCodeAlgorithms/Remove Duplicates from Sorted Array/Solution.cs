/*
    Given array of numbers in non-decreasing order.
    Remove duplicates in-place.
    The relative order should be kept the same.

    Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially.
    The remaining elements of nums are not important as well as the size of nums.
    Return k.
*/

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (!nums.Any())
        {
            return 0;
        }

        var indexOfLastUniqueElement = 0;
        foreach (var number in nums) // When would we use for loop, then we can iterate until the elements equals to last element.
        {
            // We are looking for new distinct number
            if (number != nums[indexOfLastUniqueElement]) 
            {
                nums[indexOfLastUniqueElement + 1] = number; // Place the new distinct value in correct place
                indexOfLastUniqueElement++;
            }
        }

        return indexOfLastUniqueElement + 1;
    }
}

//Solution tips:

// In-place - means that an operation or function modifies the input data directly,
// instead of creating new data as a result. This means that the operation is performed on the original data, 
// not on a copy, which can affect performance and memory usage.
// An example of an operation performed "in-place" is sorting data in place,
// that is, without creating a new array, but only by modifying the values in the existing array."

// So, we ought to use a two-pointer approach here.
// One, that would keep track of the current element in the original array and another one for just the unique elements.

// Essentially, once an element is encountered, you simply need to bypass its duplicates and move on to the next unique element.