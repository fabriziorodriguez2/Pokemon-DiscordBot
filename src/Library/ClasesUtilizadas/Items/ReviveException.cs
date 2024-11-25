// ExcepcionPokemonDebilitado.cs
public class ReviveException : Exception
{
    public ReviveException() : base() { }

    public ReviveException(string message) : base(message) { }

    public ReviveException(string message, Exception innerException) : base(message, innerException) { }
}