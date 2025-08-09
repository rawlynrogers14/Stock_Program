using System;


namespace Project3
{
    
    public class FilePathProcessor
    {
        // Method to get filename form file path without the .csv
        public string GetFileNameBeforeCsv(string filePath)
        {
            int lastBackslashIndex = filePath.LastIndexOf('\\');
            int csvIndex = filePath.IndexOf(".csv", StringComparison.OrdinalIgnoreCase);

            if (lastBackslashIndex == -1 || csvIndex == -1)
            {
                return string.Empty;
            }

            string removedPart = filePath.Substring(lastBackslashIndex + 1);

            // Remove the ".csv" extension
            if (removedPart.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                removedPart = removedPart.Substring(0, removedPart.Length - 4);
            }

            return removedPart;
        }

    
    }


}
