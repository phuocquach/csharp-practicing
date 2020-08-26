namespace CopyDetection
{
    public static class Alt_GetMaxBannerArea
    {
        public static int Solution(int[] H)
        {
            var highestBlockIndex = FindHighestIndex(H,0,H.Length);
            var highest = H[highestBlockIndex];
            var totalArea = 0;
            var areaLeft = highest*(highestBlockIndex + 1);
            var areaRight = highest*(H.Length - (highestBlockIndex + 1));

            if (areaLeft > areaRight)
            {
                var secondHighest = FindHighestIndex(H,0,highestBlockIndex);
                totalArea = areaRight + H[secondHighest] * (highestBlockIndex) ;

            }else{
                var secondHighest = FindHighestIndex(H,highestBlockIndex,H.Length);
                totalArea = areaLeft + H[secondHighest] * (H.Length - highestBlockIndex -1) ;
            }
            return totalArea;
        }

        private static int FindHighestIndex(int[] input, int start, int end)
        {
            var highest = input[start];
            var index = start;
            for(int i = start; i < end; i++)
            {
                if (highest < input[i]){
                    highest = input[i];
                    index = i;
                }
            }
            return index;
        }
    }
}