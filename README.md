# MeetupChallenge
Meetup challenge santander  
Web Api desarrollado en .NET CORE 3.1 

Sitio en Azure 
https://meetupapi.azurewebsites.net/index.html


# Getting Started
*Agregar ip en azure para poder usar el swagger  
1. Swagger  
  1- Al iniciar la aplicacion se muestra la interfaz de swagger.  
  2- Para poder usar los metodos en swagger primero hay que auntenticarse.  
  Para obtener el token hay un GET(/identity/token) de prueba.   
  3- Para poder crear una meetup es necesario primero crear un usuario y pasarle su id. Tambien hay que crear un Topico ( temas de las    meetups) y pasar su id.  
3. Biblioteca BussinessLogic  
   1- Es una biblioteca que maneja el llamado a las apis.   
   2- Falta agregar el proyecto de test  
4. Frontend WIP 
  
2.	Software dependencies
  1- Entity Framework  
  2- SwashBuckle  
  3- Automapper  
  4- NewsoftJson  
  5- IdentityServer corriendo en azure  

4.	API references    
  https://rapidapi.com/community/api/open-weather-map
