static class stringExtension
    {
        public static string LoremIpsumCut(this string original_obj, int n)
        {
            if (original_obj.Length >= n)
            {
                return original_obj.Substring(0, n) + " ...";
            }
            else if (original_obj.Length == n)
            {
                return original_obj + " ...";
            }
            else
            {
                return original_obj;
            }
        }
    }
