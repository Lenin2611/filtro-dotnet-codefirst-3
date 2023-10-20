# Lenin-Ropa

### HttpGet:

###### General: 

http://localhost:5253/api/Entity

###### URL: 

- http://localhost:5253/api/Cargo

- http://localhost:5253/api/Cliente

- http://localhost:5253/api/Color

- http://localhost:5253/api/Departamento

- http://localhost:5253/api/DetalleOrden

- http://localhost:5253/api/DetalleVenta

- http://localhost:5253/api/Empleado

- http://localhost:5253/api/Empresa

- http://localhost:5253/api/Estado

- http://localhost:5253/api/FormaPago

- http://localhost:5253/api/Genero

- http://localhost:5253/api/Insumo

- http://localhost:5253/api/Inventario

- http://localhost:5253/api/Municipio

- http://localhost:5253/api/Orden

- http://localhost:5253/api/Pais

- http://localhost:5253/api/Prenda

- http://localhost:5253/api/Proveedor

- http://localhost:5253/api/Talla

- http://localhost:5253/api/TipoEstado

- http://localhost:5253/api/TipoPersona

- http://localhost:5253/api/TipoProteccion

- http://localhost:5253/api/Venta

### HttpGetById y HttpDelete:

###### General: 

http://localhost:5253/api/Entity/id

###### URL: 

- http://localhost:5253/api/Cargo/1

- http://localhost:5253/api/Cliente/1

- http://localhost:5253/api/Color/1

- http://localhost:5253/api/Departamento/1

- http://localhost:5253/api/DetalleOrden/1

- http://localhost:5253/api/DetalleVenta/1

- http://localhost:5253/api/Empleado/1

- http://localhost:5253/api/Empresa/1

- http://localhost:5253/api/Estado/1

- http://localhost:5253/api/FormaPago/1

- http://localhost:5253/api/Genero/1

- http://localhost:5253/api/Insumo/1

- http://localhost:5253/api/Inventario/1

- http://localhost:5253/api/Municipio/1

- http://localhost:5253/api/Orden/1

- http://localhost:5253/api/Pais/1

- http://localhost:5253/api/Prenda/1

- http://localhost:5253/api/Proveedor/1

- http://localhost:5253/api/Talla/1

- http://localhost:5253/api/TipoEstado/1

- http://localhost:5253/api/TipoPersona/1

- http://localhost:5253/api/TipoProteccion/1

- http://localhost:5253/api/Venta/1

### HttpPost y HttpPut:

###### General:

Post: http://localhost:5253/Entity

Put: http://localhost:5253/Entity/id

###### LayOut: 

Cargo:

- Post: http://localhost:5253/api/Cargo Put: http://localhost:5253/api/Cargo/1

  ```json
  { 
  	"descripcion": "Vendedor",
  	"sueldoBase": 500
  }
  ```

- Post: http://localhost:5253/api/Cliente Put: http://localhost:5253/api/Cliente/1

  ```json
  {
    "idCliente": 102569878,
    "nombre": "Pepe",
    "fechaRegistro": "2023-10-20",
    "idMunicipio": 1,
    "idTipoPersona": 1
  }
  ```

- Post: http://localhost:5253/api/Color Put: http://localhost:5253/api/Color/1

  ```json
  {
    "descripcion": "Azul"
  }
  ```

- Post: http://localhost:5253/api/Departamento Put: http://localhost:5253/api/Departamento/1

  ```json
  {
    "nombre": "Santander",
    "idPais": 1
  }
  ```

- Post: http://localhost:5253/api/DetalleOrden Put: http://localhost:5253/api/DetalleOrden/1

  ```json
  {
    "cantidadProducir": 200,
    "cantidadProducida": 180,
    "idOrden": 1,
    "idPrenda": 1,
    "idColor": 1,
    "idEstado": 1
  }
  ```

- Post: http://localhost:5253/api/DetalleVenta Put: http://localhost:5253/api/DetalleVenta/1

  ```json
  {
    "cantidad": 200,
    "valorUnit": 30,
    "idVenta": 1,
    "idProducto": 1,
    "idTalla": 1
  }
  ```

- Post: http://localhost:5253/api/Empleado Put: http://localhost:5253/api/Empleado/1

  ```json
  {
    "idEmp": 123456,
    "nombre": "Karen",
    "fechaIngreso": "2023-10-20",
    "idCargo": 1,
    "idMunicipio": 1
  }
  ```

- Post: http://localhost:5253/api/Empresa Put: http://localhost:5253/api/Empresa/1

  ```json
  {
    "nit": 98765,
    "razonSocial": "Juridico",
    "representanteLegal": "Carlos",
    "fechaCreacion": "2023-10-20",
    "idMun": 1
  }
  ```

- Post: http://localhost:5253/api/Estado Put: http://localhost:5253/api/Estado/1

  ```json
  {
    "descripcion": "Roto en la bota",
    "idTipoEstado": 1
  }
  ```

- Post: http://localhost:5253/api/FormaPago Put: http://localhost:5253/api/FormaPago/1

  ```json
  {
    "descripcion": "Credito"
  }
  ```

- Post: http://localhost:5253/api/Genero Put: http://localhost:5253/api/Genero/1

  ```json
  {
    "descripcion": "Masculino"
  }
  ```

- Post: http://localhost:5253/api/Insumo Put: http://localhost:5253/api/Insumo/1

  ```json
  {
    "nombre": "Venta camisa roja",
    "valorUnit": 12000,
    "stockMin": 50,
    "stockMax": 300
  }
  ```

- Post: http://localhost:5253/api/Inventario Put: http://localhost:5253/api/Inventario/1

  ```json
  {
    "codInv": 34567,
    "valorVtaCop": 20000,
    "valorVtaUsd": 5,
    "idPrenda": 1
  }
  ```

- Post: http://localhost:5253/api/Municipio Put: http://localhost:5253/api/Municipio/1

  ```json
  {
    "nombre": "Bucaramanga",
    "idDep": 1
  }
  ```

- Post: http://localhost:5253/api/Orden Put: http://localhost:5253/api/Orden/1

  ```json
  {
    "fecha": "2023-10-20",
    "idCliente": 1,
    "idEmpleado": 1,
    "idEstado": 1
  }
  ```

- Post: http://localhost:5253/api/Pais Put: http://localhost:5253/api/Pais/1

  ```json
  {
    "nombre": "Colombia"
  }
  ```

- Post: http://localhost:5253/api/Prenda Put: http://localhost:5253/api/Prenda/1

  ```json
  {
    "idPrenda": 1298456,
    "nombre": "Camisa",
    "valorUnitCop": 28000,
    "valorUnitUsd": 7,
    "idEstado": 1,
    "idTipoProteccion": 1,
    "idGenero": 1
  }
  ```

- Post: http://localhost:5253/api/Proveedor Put: http://localhost:5253/api/Proveedor/1

  ```json
  {
    "nitProveedor": 6421306,
    "nombre": "Lenay",
    "idTipoPersona": 1,
    "idMunicipio": 1
  }
  ```

- Post: http://localhost:5253/api/Talla Put: http://localhost:5253/api/Talla/1

  ```json
  {
    "descripcion": "L"
  }
  ```

- Post: http://localhost:5253/api/TipoEstado Put: http://localhost:5253/api/TipoEstado/1

  ```json
  {
    "descripcion": "Dañado"
  }
  ```

- Post: http://localhost:5253/api/TipoPersona Put: http://localhost:5253/api/TipoPersona/1

  ```json
  {
    "nombre": "Empleado"
  }
  ```

- Post: http://localhost:5253/api/TipoProteccion Put: http://localhost:5253/api/TipoProteccion/1

  ```json
  {
    "descripcion": "Seguro"
  }
  ```

  

- Post: http://localhost:5253/api/Venta Put: http://localhost:5253/api/Venta/1

  ```json
  {
    "fecha": "2023-10-20",
    "idEmpleado": 1,
    "idCliente": 1,
    "idFormaPago": 1
  }
  ```

  