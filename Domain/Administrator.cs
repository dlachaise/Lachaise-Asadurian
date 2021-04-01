using System;
namespace Domain
{
    public class Administrator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        Administrator()
        {
            Id = Guid.NewGuid();
        }
        public Administrator Update(Administrator entity)
        {
            if (entity.Name != null)
                Name = entity.Name;
            if (entity.Email != null)
                Email = entity.Email;
            if (entity.Password != null)
                Password = entity.Password;
            return this;
        }

    }
}