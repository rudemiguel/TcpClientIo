using System;

namespace Drenalol.Base
{
    public abstract class TcpPackageConverter
    {
        public abstract byte[] ConvertTo(object input);
        public abstract object ConvertBackTo(byte[] input);
    }
    
    public abstract class TcpPackageConverter<T> : TcpPackageConverter
    {
        public sealed override byte[] ConvertTo(object input)
        {
            if (input != null && input is T genericInput)
                return Convert(genericInput);

            throw new ArgumentException(nameof(input));
        }

        public abstract byte[] Convert(T input);

        public sealed override object ConvertBackTo(byte[] input)
        {
            if (input != null)
                return ConvertBack(input);
            
            throw new ArgumentException(nameof(input));
        }
        
        public abstract T ConvertBack(byte[] input);
    }
}