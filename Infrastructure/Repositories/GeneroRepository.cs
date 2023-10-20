using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GeneroRepository : GenericRepository<Genero>, IGenero
    {
        private readonly LeninRopaContext context;

        public GeneroRepository(LeninRopaContext context) : base(context)
        {
            this.context = context;
        }
    }
}