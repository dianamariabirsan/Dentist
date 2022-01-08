using System;
namespace Dentist
{
    public class Programare
    {
        public int ProgramareId { get; set; }

        public int ClientId { get; set; }

        public int CabinetId { get; set; }

        public String Data { get; set; }

        public String Client
        {
            get
            {
                using (var context = new Services.Context())
                {
                    Client obj = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Clienti, c => c.ClientId == this.ClientId).Result;
                    return obj.Nume + " " + obj.Prenume;
                }
            }
        }
        public String Cabinet
        {
            get
            {
                using (var context = new Services.Context())
                {
                    Cabinet obj = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Cabinete, c => c.CabinetId == this.CabinetId).Result;
                    return obj.Nume;
                }
            }
        }
    }
}