using System;
namespace MSP.BetterCalm.Domain
{
    public class Administrator
    {
      
        public Guid Id { get; set; }
        public string Name { get; set; }
         public string Email { get; set; }
         public string Password { get; set; }
        public bool IsActive { get; set; }

         public Administrator()
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


        public override bool Equals(Object obj)
        {
            var result = false;

            if (obj is Administrator administrator)
            {
                result = this.Id == administrator.Id && this.Email.Equals(administrator.Email);
            }

            return result;
        }
  

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

}