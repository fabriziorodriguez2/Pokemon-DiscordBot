// ExcepcionPokemonDebilitado.cs
public class CureException : Exception
{
    public CureException() : base() { }

    public CureException(string message) : base(message) { }

    public CureException(string message, Exception innerException) : base(message, innerException) { }
}