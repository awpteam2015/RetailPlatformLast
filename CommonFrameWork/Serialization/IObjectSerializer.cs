namespace CommonFrameWork.Serialization
{
    /// <summary>
    /// Represents that the implemented classes are object serializers.
    /// </summary>
    public interface IObjectSerializer
    {

        string Serialize<TObject>(TObject obj);

        TObject Deserialize<TObject>(string stream);
    }
}