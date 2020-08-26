using System;
using System.Collections.Generic;
using System.Linq;
namespace BuildingBlock
{
    public class Solution
    {
        public int solution(int[] H) 
        {
            if (H.Length == 1)
            {
                return H[0];
            }
            else if (H.Length == 2)
            {
                return H[0] + H[1];
            }else
            {
                return CalculateTotal(H);
            }

        }

        private int CalculateTotal(int[] input)
        {
            var max = input[0];
            var maxLeft = max;
            var maxRight = input[1];
            var positionMax = 0;
            var minArea = DetectMinArea(max, maxLeft, maxRight, positionMax, input.Length);
            var index = 1;
            
            for(index = 1; index < input.Length - 1 ; index++ )
            {
                if (input[index] > max)
                {
                    positionMax = index;
                    maxLeft = max;
                    max = input[index];
                    maxRight = input[index + 1];
                }
                else if (input[index] == max)
                {
                    maxRight = input[index];
                    minArea = DetectMinArea(max, maxLeft, maxRight, positionMax, input.Length);
                    
                    var tempMaxRight = input[index + 1];
                    for(int j = index + 1; j < input.Length; j++)
                    {
                        if (tempMaxRight < input[j])
                        {
                            tempMaxRight = input[j];
                        }
                    }
                    var tempAreaMoveMax = DetectMinArea(max, max, tempMaxRight, index, input.Length);
                    
                    if (tempAreaMoveMax < minArea)
                    {
                        positionMax = index;
                        maxLeft = max;
                        max = input[index];
                        maxRight = input[index + 1];
                    }
                }
                else if (input[index] > maxRight)
                {
                    maxRight = input[index];
                }
                minArea = DetectMinArea(max, maxLeft, maxRight, positionMax, input.Length);

            }

            if (input[index] > max)
            {
                positionMax = index;
                maxLeft = max;
                max = input[index];
                maxRight = input[index];
                
            }
            else if (input[index] > maxRight)
            {
                maxRight = input[index];
            }
            minArea = DetectMinArea(max, maxLeft, maxRight, positionMax, input.Length);

            return minArea;
        }

        private int DetectMinArea(int max, int maxLeft, int maxRight, int positionMax, int length)
        {
            var maxInRightArea = maxLeft * positionMax + (length - positionMax) * max;
            var maxInLeftArea = max * (positionMax + 1) + (length - positionMax - 1) * maxRight;

            return maxInRightArea > maxInLeftArea 
                ? maxInLeftArea 
                : maxInRightArea;
        }

        private int OldSolution(int[] H)
        {
            var maxHigh = FindMaxTall(H);
            var maxHighPosition = FindMaxTallPosition(maxHigh, H).ToArray();
            var area = CalculateArea(H,maxHighPosition[0]);

            for(int index = 1; index < maxHighPosition.Length; index ++)
            {
                var newArea = CalculateArea(H,maxHighPosition[index]);
                if (newArea < area)
                {
                    area = newArea;
                }
            }

            return area;
        }

        private int CalculateArea(int[] input, int position)
        {
            var maxOnLeft = 0;
            for(var index = 0; index < position; index++)
            {
                if (maxOnLeft < input[index])
                {
                    maxOnLeft = input[index];
                }
            }

            var maxOnRight = 0;

            for(var index = position + 1; index < input.Length; index++)
            {
                if (maxOnRight < input[index])
                {
                    maxOnRight = input[index];
                }
            }

            var firstArea = maxOnLeft * position + (input.Length - position)* input[position];
            var secondArea = input[position] * (position + 1) + (input.Length - position - 1) * maxOnRight;

            return firstArea > secondArea 
                ? secondArea 
                : firstArea;
        }

        public int FindMaxTall(int[] input)
        {
            var result = input[0];
            foreach(var item in input)
            {
                if (result < item)
                {
                    result = item;
                }
            }
            return result;
        }

        public IEnumerable<int> FindMaxTallPosition(int max, int[] input)
        {
            for(var index = 0; index < input.Length; index ++)
            {
                if (input[index] == max)
                {
                    yield return index;
                }
            }
        }
    }
}
