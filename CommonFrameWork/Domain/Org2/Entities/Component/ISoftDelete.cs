namespace CommonFrameWork.Domain.Entities.Component
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
