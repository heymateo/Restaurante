# Sitio Web para un Restaurante

Proyecto final del curso Programación Avanzada en Web del II Cuatrimestre del 2024, Universidad Fidélitas. 

Profesor: Jose Andrés Arias Brenes.

## Integrantes

Mateo Esquivel Rodríguez, Cristofer Andrés Marín Lazo, Ariana Jenkins Carrillo y Jerry Fabricio Campos Arias.

## Descripción

Sitio web de un restaurante que cuenta con 3 tipos de usuarios (Administrador, Empleado, Chef). Cada rol tiene responsabilidades diferentes, en el caso del Administrador puede hacer un CRUD del menú, un CRUD de las mesas existentes del local, un CRUD de los chefs, un CRUD de los empleados del restaurante y puede ver un historial de las cuentas. Por el lado del rol de Empleado pueden asignar clientes a una mesa y hacer un CRUD de órdenes. Y por último en el rol de Chef se encargará de finalizar las órdenes.

## Roles

| Administrador   | Empleado                        | Chef                    
|--------------   |--------------                   |--------------           
| CRUD Menú       | Ver mesas disponibles           | Ver menú                
| CRUD Mesas      | Asignar clientes a una mesa     | Ver y finalizar órdenes
| CRUD Chefs      | CRUD Órdenes       
| CRUD Empleados  |
| Ver Cuentas     |

## Módulos

| Autenticación    | Menú             | Órdenes      | Mesas        | Cuentas      | Usuarios
|--------------    |--------------    |--------------|--------------|--------------|--------------
| Administrador    | Administrador    |              | Administrador|Administrador |Administrador
| Empleado         |  Empleado        |  Empleado    | Empleado     |              |   
| Chef             |  Chef            |  Chef        |              |              |  

## Diagrama Entidad-Relación


## Características
- Desarrollado en ASP.NET Core v7
- Escrito en C#
- Uso de API's para el consumo de datos
- SQL Server como base de datos
