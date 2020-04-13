# PruebaBluesoft

BACK-END
1. En Repositorio descargado, ingresar a la carpeta WebApi y abrir la solución.
2. Ingresar al proyecto por medio de VS y dar click derecho a la solucion "WebApi"(Primera linea en Explorador de soluciones) y buscar opción Restaurar Paquetes de NuGet.
3. Dentro de la solución, en la ruta Src/Layers/3. Presentation/ dar click derecho sobre el proyecto Api.Presentation y dar click a Establecer como proyecto de inicio.
4. Ejecutar el proyecto con la tecla F5 o buscar el boton IIS Express en la parte superior central.

NOTA: Las migraciones se corren automaticamente, si es necesario, con la siguiente instrucción que esta en el startup.
   using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
   {
   var context = serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
   context.Database.Migrate();
   }

FRONT-END
1. En Repositorio descargado, ingresar desde PS o CMD a la ruta ClientApp/book-manager.
2. Ejecutar npm i.
3. Ejecutar ng serve -o