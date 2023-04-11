namespace Domain.Exceptions;

public class InvalidUsernameLengthLong : Exception
{
    public InvalidUsernameLengthLong()
    {
    }

    public InvalidUsernameLengthLong(string length) : base(String.Format("Username is larger than 16 chars, length {0}", length))
    {
    }
}