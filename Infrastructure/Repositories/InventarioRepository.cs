using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly LeninRopaContext context;

        public InventarioRepository(LeninRopaContext context) : base(context)
        {
            this.context = context;
        }
    }
}