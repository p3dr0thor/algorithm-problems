public class Solution {
	
	//Time complexity: O(m+n)
	//Space complexity: O(1) (min length of strs)
	//Solution: Iterate over characters of all words instead of compare word by word. At the first ocurrence of different char at position [i], return prefix.
    public string LongestCommonPrefix(string[] strs) {
        string longestCommonPrefix = "";
        for (int i = 0; i < strs[0].Length; i++)
        {
            for (int j = 1; j < strs.Length; j++)
            {
                if (i > strs[j].Length - 1 || strs[0][i] != strs[j][i])
                {
                    return longestCommonPrefix;
                }
            }
            longestCommonPrefix += strs[0][i];
        }
        return longestCommonPrefix;
    }
}