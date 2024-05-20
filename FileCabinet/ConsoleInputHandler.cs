using System.Reflection.Metadata;

namespace FileCabinet
{
    public static class ConsoleInputHandler
    {
        public static T GetInput<T>(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (TryParseInput<T>(input, out T result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                return GetInput<T>(message);
            }
        }

        private static bool TryParseInput<T>(string input, out T result)
        {
            result = default;
            try {
                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Int32:
                        return int.TryParse(input, out int intValue) && (result = (T)(object)intValue) != null;
                    case TypeCode.UInt16:
                        return ushort.TryParse(input, out ushort ushortValue) && (result = (T)(object)ushortValue) != null;
                    case TypeCode.UInt32:
                        return uint.TryParse(input, out uint uintValue) && (result = (T)(object)uintValue) != null;
                    case TypeCode.Decimal:
                        return decimal.TryParse(input, out decimal decimalValue) && (result = (T)(object)decimalValue) != null;
                    case TypeCode.String:
                        result = (T)(object)input;
                        return true;
                    case TypeCode.DateTime:
                        return DateTime.TryParse(input, out DateTime dateTimeValue) && (result = (T)(object)dateTimeValue) != null;
                    default:
                        throw new ArgumentException($"Unsupported data type: {typeof(T).Name}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}