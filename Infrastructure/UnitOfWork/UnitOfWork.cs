using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LeninRopaContext _context;
        private ICargo _Cargos;
        private ICliente _Clientes;
        private IColor _Colores;
        private IDepartamento _Departamentos;
        private IDetalleOrden _DetalleOrdenes;
        private IDetalleVenta _DetalleVentas;
        private IEmpleado _Empleados;
        private IEmpresa _Empresas;
        private IEstado _Estados;
        private IFormaPago _FormaPagos;
        private IGenero _Generos;
        private IInsumo _Insumos;
        private IInventario _Inventarios;
        private IMunicipio _Municipios;
        private IOrden _Ordenes;
        private IPais _Paises;
        private IPrenda _Prendas;
        private IProveedor _Proveedores;
        private ITalla _Tallas;
        private ITipoEstado _TipoEstados;
        private ITipoPersona _TipoPersonas;
        private ITipoProteccion _TipoProtecciones;
        private IVenta _Ventas;

        public UnitOfWork(LeninRopaContext context)
        {
            _context = context;
        }

        public ICargo Cargos
        {
            get
            {
                if (_Cargos == null)
                {
                    _Cargos = new CargoRepository(_context);
                }
                return _Cargos;
            }
        }
        public ICliente Clientes
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(_context);
                }
                return _Clientes;
            }
        }
        public IColor Colores
        {
            get
            {
                if (_Colores == null)
                {
                    _Colores = new ColorRepository(_context);
                }
                return _Colores;
            }
        }
        public IDepartamento Departamentos
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }
        public IDetalleOrden DetalleOrdenes
        {
            get
            {
                if (_DetalleOrdenes == null)
                {
                    _DetalleOrdenes = new DetalleOrdenRepository(_context);
                }
                return _DetalleOrdenes;
            }
        }
        public IDetalleVenta DetalleVentas
        {
            get
            {
                if (_DetalleVentas == null)
                {
                    _DetalleVentas = new DetalleVentaRepository(_context);
                }
                return _DetalleVentas;
            }
        }
        public IEmpleado Empleados
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(_context);
                }
                return _Empleados;
            }
        }
        public IEmpresa Empresas
        {
            get
            {
                if (_Empresas == null)
                {
                    _Empresas = new EmpresaRepository(_context);
                }
                return _Empresas;
            }
        }
        public IEstado Estados
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(_context);
                }
                return _Estados;
            }
        }
        public IFormaPago FormaPagos
        {
            get
            {
                if (_FormaPagos == null)
                {
                    _FormaPagos = new FormaPagoRepository(_context);
                }
                return _FormaPagos;
            }
        }
        public IGenero Generos
        {
            get
            {
                if (_Generos == null)
                {
                    _Generos = new GeneroRepository(_context);
                }
                return _Generos;
            }
        }
        public IInsumo Insumos
        {
            get
            {
                if (_Insumos == null)
                {
                    _Insumos = new InsumoRepository(_context);
                }
                return _Insumos;
            }
        }
        public IInventario Inventarios
        {
            get
            {
                if (_Inventarios == null)
                {
                    _Inventarios = new InventarioRepository(_context);
                }
                return _Inventarios;
            }
        }
        public IMunicipio Municipios
        {
            get
            {
                if (_Municipios == null)
                {
                    _Municipios = new MunicipioRepository(_context);
                }
                return _Municipios;
            }
        }
        public IOrden Ordenes
        {
            get
            {
                if (_Ordenes == null)
                {
                    _Ordenes = new OrdenRepository(_context);
                }
                return _Ordenes;
            }
        }
        public IPais Paises
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }
        public IPrenda Prendas
        {
            get
            {
                if (_Prendas == null)
                {
                    _Prendas = new PrendaRepository(_context);
                }
                return _Prendas;
            }
        }
        public IProveedor Proveedores
        {
            get
            {
                if (_Proveedores == null)
                {
                    _Proveedores = new ProveedorRepository(_context);
                }
                return _Proveedores;
            }
        }
        public ITalla Tallas
        {
            get
            {
                if (_Tallas == null)
                {
                    _Tallas = new TallaRepository(_context);
                }
                return _Tallas;
            }
        }
        public ITipoEstado TipoEstados
        {
            get
            {
                if (_TipoEstados == null)
                {
                    _TipoEstados = new TipoEstadoRepository(_context);
                }
                return _TipoEstados;
            }
        }
        public ITipoPersona TipoPersonas
        {
            get
            {
                if (_TipoPersonas == null)
                {
                    _TipoPersonas = new TipoPersonaRepository(_context);
                }
                return _TipoPersonas;
            }
        }
        public ITipoProteccion TipoProtecciones
        {
            get
            {
                if (_TipoProtecciones == null)
                {
                    _TipoProtecciones = new TipoProteccionRepository(_context);
                }
                return _TipoProtecciones;
            }
        }
        public IVenta Ventas
        {
            get
            {
                if (_Ventas == null)
                {
                    _Ventas = new VentaRepository(_context);
                }
                return _Ventas;
            }
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}