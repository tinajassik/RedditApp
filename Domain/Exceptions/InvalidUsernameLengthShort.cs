namespace Domain.Exceptions;

public class InvalidUsernameLengthShort : Exception
{
    public InvalidUsernameLengthShort()
    {
    }

    public InvalidUsernameLengthShort(string length) : base(String.Format("Username is shorter than 3 chars, length: {0}", length))
    {
        
    }


}