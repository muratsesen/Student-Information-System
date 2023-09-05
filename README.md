Database aktarımı için API/appsettings.json içinde 'connection string' verisini değiştirilmeli
Ben postgresql kullandım. 
Swagger UI kapalı. Açmak için launchSettings dosyasında gerekli değişikliği yapabilirsiniz.
Postman collection repo içinde var ancak UI tarafında gerekli implementasyonlar bulunmaktadır.

Projeyi çalıştırmak için:

1- ``git clone https://github.com/muratsesen/Student-Information-System.git``

2-  ``cd Student-Information-System / Api``

3- ``dotnet run``

4- ``cd ../UI``

5- ``npm i``

6- ``npm run dev``

7- Tarayıcıda http://localhost:5173/ adresine gidin

Admin ve kullanıcı hesaplarına giriş yapabilirsiniz.