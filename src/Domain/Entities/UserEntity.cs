namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
