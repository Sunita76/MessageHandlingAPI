# A Service for sending and retrieving messages   

  

The service contains endpoints for the following functions.    

1. Submit a message to a defined receiver.    

2. Fetch new messages.    

3. Fetch messages for a range.    

4. Delete a message.    

5. Delete multiple messages.    

The service is implemented in the form of REST API 
 
## Getting Started 

 

### 1. Clone the repository   

To start, clone the repository to the local machine using the following command:   

```   

git clone  https://github.com/Sunita76/MessageHandlingAPI.git 

``` 

Or, download the ZIP file of the repository from GitHub and extract it to a local folder.   

### 2. Open the solution in Visual Studio   

Navigate to the folder where you cloned the repository and select the **.sln** file to open it in Visual Studio.   

### 3. Set up the Database   

Configure the connection string in **appsettings.json**   

``` 

{ 

  "ConnectionStrings": { 

    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MessageDB;Trusted_Connection=True;" 

  } 

}   

```   

If you need to apply database migrations, open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run:   

```   

update-database   

```   

### 4. Build the Solution   

In Visual Studio, go to Build-> Build the solution  

### 5. Run the API   

Press F5 or click on the Run button to start the application.   

### 6. Test the API   

Once the API is running, test it using PostMan or Swagger in the browser. Swagger will provide the documentation of the endpoints.   

 
