
//Time complexity: O(m*n)
//Space complexity: O(m+n) (result array)
//Solution: Convert char <--> int with ASCII offset. Multiply numbers and add partial result on correct position and calculate extra sum for next iteration.
//Remove leading '0' and format output with trim();

public class Solution {
    private const int OFFSET_NUMBER_ASCII = 48;
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0")
                return "0";

		char[] result = new char[num1.Length + num2.Length];
		int multiplier1, multiplier2, i, j;

		for (i = num1.Length - 1; i >= 0; i--)
		{
			multiplier1 = num1[i] - OFFSET_NUMBER_ASCII;
			int extraSum = 0;
			for (j = num2.Length - 1; j >= 0; j--)
			{
				multiplier2 = num2[j] - OFFSET_NUMBER_ASCII;

				int partialResult = multiplier1 * multiplier2 + extraSum;
				extraSum = partialResult / 10;
				partialResult = (result[i + j + 1] == '\0' ? 0 : result[i + j + 1] - OFFSET_NUMBER_ASCII) + (partialResult % 10);
				result[i + j + 1] = (char)((partialResult % 10) + OFFSET_NUMBER_ASCII);
				extraSum += partialResult / 10;
			}

			result[i + j + 1] = (char)(extraSum + OFFSET_NUMBER_ASCII);
		}

		if (result[0] == '0')
			result[0] = ' ';

		return new string(result).TrimStart();
    }
}