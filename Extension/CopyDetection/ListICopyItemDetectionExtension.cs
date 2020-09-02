using System;
using System.Collections.Generic;
namespace CopyDetection
{
    public static class ListICopyItenExtension
    {
        public static List<string> DetectCopied(this IList<string> source, Predicate<int> copiedLengthPredicate )
        {
            var result = new List<string>();

            for(var index = 0; index < source.Count; index ++)
            {
                var item = source[index];

                if (item.ContainCopyString(copiedLengthPredicate) 
                    && !result.Contains(item))
                {
                    result.Add(item);
                }

                for (var subIndex = index + 1; subIndex < source.Count; subIndex++)
                {
                    var containCopyItem = source[subIndex];

                    if (item.ContainCopyString(containCopyItem, copiedLengthPredicate))
                    {
                        if (!result.Contains(item))
                        {
                            result.Add(item);
                        }

                        if (!result.Contains(containCopyItem))
                        {
                            result.Add(containCopyItem);
                        }
                    }
                }
            }

            return result;
        }
    }
}