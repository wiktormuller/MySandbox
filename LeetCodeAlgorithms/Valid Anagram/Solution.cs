/*
    Given two strings s and t, return true if t is an anagram of s, and false otherwise.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
*/
// Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?

public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }

        var frequenciesOfCharacters = new Dictionary<char, int>(); // Or we can use predefined array with 26 characters and default value equals 0

        for(int i = 0; i < s.Length; i++)
        {
            if (!frequenciesOfCharacters.ContainsKey(s[i])) // Or we can use .TryAdd method
            {
                frequenciesOfCharacters[s[i]] = 0; // Seed
            }

            if (!frequenciesOfCharacters.ContainsKey(t[i])) // Or we can use .TryAdd method
            {
                frequenciesOfCharacters[t[i]] = 0; // Seed
            }
            
            frequenciesOfCharacters[s[i]]++;
            frequenciesOfCharacters[t[i]]--;
        }

        return frequenciesOfCharacters.Values.All(frequencyOfCharacter => frequencyOfCharacter == 0);
    }
}

// Also we can sort characters in both strings and then compare both collections.
// Also we can use string.Contains method, but it's naive implementation (works only for words without duplicates).