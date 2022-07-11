# Travel Challenge

### Objetivo
Se debe crear una aplicación web que permita asignar viajes a diferentes ciudades para los próximos 10 días máximo y que chequee el estado del tiempo para el día que se deberá realizar el viaje, en caso que el pronóstico indique lluvia, se deberá ofrecer al operador la posibilidad de reprogramarlo para otro día o cancelarlo.

### Detalles UI
* Deberá tener una pantalla donde se puedan ver todos los viajes ya programados en una grilla y que permita filtrar los viajes al menos por fechas, destino y/o tipo de vehículos.
* Deberá tener un botón para crear un nuevo viaje abriendo un popup para completar los datos.
* Deberá tener también la posibilidad de eliminar o reprogramar un viaje seleccionandolo de la grilla.

### APIS
Para obtener el estado del tiempo se sugiere utilizar la [API gratuita](https://openweathermap.org/api/forecast30) pero pueden buscar y utilizar otra que encuentren en internet.

### Tener en cuenta que se necesita
- un ABM de vehículos en el cual al menos se puedan ingresar el tipo de vehículo (auto, camión, moto, etc), la patente, marca, y cualquier otro dato que consideren necesario.
- un ABM de ciudades (si la API que utilizan para los datos del tiempo ofrece información sólo de otros países, no hay problema, en el ABM ingresan ciudades de ese país).

### Tecnologías

* .Net Core
* Entity Framework Core
* SQL Server
