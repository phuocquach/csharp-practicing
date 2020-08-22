using System;
using System.Collections.Generic;

namespace CopyDetection
{
    public static class StringCopyDetection
    {
        public static bool ContainCopyString(this string source, string containCopyString, Predicate<int> predicate)
        {
            for(int sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
            {
                for (int containCopyStringIndex = 0; containCopyStringIndex < containCopyString.Length; containCopyStringIndex++)
                {
                    var copiedLength = 0;

                    while (source[sourceIndex + copiedLength] == containCopyString[containCopyStringIndex + copiedLength])
                    {
                        copiedLength++;
                        if (sourceIndex + copiedLength >= source.Length 
                            || containCopyStringIndex + copiedLength >= containCopyString.Length)
                        {
                            break;
                        }
                    }

                    if (predicate(copiedLength))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ContainCopyString(this string source, Predicate<int> predicate)
        {
            for (int sourceIndex = 0; sourceIndex < source.Length - 1; sourceIndex++)
            {
                for (int subIndex = sourceIndex + 1; subIndex < source.Length; subIndex++)
                {
                    var copiedLength = 0;

                    while (source[sourceIndex + copiedLength] == source[subIndex + copiedLength])
                    {
                        copiedLength++;
                        if (sourceIndex + copiedLength >= source.Length
                            || subIndex + copiedLength >= source.Length)
                        {
                            break;
                        }
                    }

                    if (predicate(copiedLength))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
