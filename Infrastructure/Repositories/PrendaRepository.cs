using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PrendaRepository : GenericRepository<Prenda>, IPrenda
    {
        private readonly LeninRopaContext context;

        public PrendaRepository(LeninRopaContext context) : base(context)
        {
            this.context = context;
        }
    }
}