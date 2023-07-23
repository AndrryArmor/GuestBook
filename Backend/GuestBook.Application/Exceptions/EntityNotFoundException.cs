using GuestBook.Domain.Entities;

namespace GuestBook.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type entityType)
            : base($"Entity of type {entityType.Name} with id {id} was not found.")
        {
            Id = id;
            EntityType = entityType;
        }

        public int Id { get; }
        public Type EntityType { get; }
    }
}
