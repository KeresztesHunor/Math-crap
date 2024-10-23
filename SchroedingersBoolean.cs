using System.Diagnostics.CodeAnalysis;

namespace MathCrap
{
    internal struct SchroedingersBoolean() : IComparable, IConvertible, IComparable<bool>, IEquatable<bool>, ISpanParsable<SchroedingersBoolean>
    {
        bool? value { get; set; } = null;

        static readonly Random rnd = new Random();

        public bool Equals(bool other) => ((bool)this).Equals(other);

        public int CompareTo(bool other) => ((bool)this).CompareTo(other);

        public int CompareTo(object? obj) => ((bool)this).CompareTo(obj);

        public TypeCode GetTypeCode() => ((bool)this).GetTypeCode();

        public bool ToBoolean(IFormatProvider? provider) => this;

        public byte ToByte(IFormatProvider? provider) => Convert.ToByte(this);

        public char ToChar(IFormatProvider? provider) => (false as IConvertible).ToChar(provider); // throws invalid cast exception

        public DateTime ToDateTime(IFormatProvider? provider) => (false as IConvertible).ToDateTime(provider); // throws invalid cast exception

        public decimal ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(this);

        public double ToDouble(IFormatProvider? provider) => Convert.ToDouble(this);

        public short ToInt16(IFormatProvider? provider) => Convert.ToInt16(this);

        public int ToInt32(IFormatProvider? provider) => Convert.ToInt32(this);

        public long ToInt64(IFormatProvider? provider) => Convert.ToInt64(this);

        public sbyte ToSByte(IFormatProvider? provider) => Convert.ToSByte(this);

        public float ToSingle(IFormatProvider? provider) => Convert.ToSingle(this);

        public ushort ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(this);

        public uint ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(this);

        public ulong ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(this);

        public object ToType(Type conversionType, IFormatProvider? provider) => (((bool)this) as IConvertible).ToType(conversionType, provider);

        public string ToString(IFormatProvider? provider) => ToString();

        public override string ToString() => ((bool)this).ToString();

        public override bool Equals([NotNullWhen(true)] object? obj) => ((bool)this).Equals(obj);

        public override int GetHashCode() => ((bool)this).GetHashCode();

        public static SchroedingersBoolean Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => TryParse(s, provider, out SchroedingersBoolean result) ? result : default;

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out SchroedingersBoolean result)
        {
            result = default;
            return true;
        }

        public static SchroedingersBoolean Parse(string s, IFormatProvider? provider) => Parse(s.AsSpan(), provider);

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out SchroedingersBoolean result) => TryParse(s.AsSpan(), provider, out result);

        public static implicit operator bool(SchroedingersBoolean schroedingersBoolean) => schroedingersBoolean.value ??= rnd.NextSingle() < 0.5f;
    }
}
