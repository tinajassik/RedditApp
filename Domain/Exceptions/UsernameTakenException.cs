namespace Domain.Exceptions;

public class UsernameTakenException : Exception 
{
    public UsernameTakenException(string name) : base(String.Format("Username already taken: {0}", name))
    {
    }
    
}