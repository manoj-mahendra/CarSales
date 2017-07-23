# CarSales
•	Dealer can Create, Update or Delete their car stock.

•	Dealer can update their own info.

•	Dealer can request an HTML email of their stock summary. 

1.	Car Stock created today, this week and this month
2.	Car Stock archived today, this week and this month 

•	Admin can Create, Update, delete Dealer

•	Other application can consume this API to search against all the car stocks by any combination of Car Info or by dealer name

# Admin Controller

1 http://localhost:1494/api/admin/GetAllDealers -	Gets all dealers

2	http://localhost:1494/api/admin/GetDealer/4	 - Gets dealer by Dealer ID 

3	http://localhost:1494/api/admin/PostDealer - 	Add Dealer

.Data	{
"name": "Hello",
"email": "Hello@testmail.com.au",
"address":  "Mulgrave Melbourne VIC"
}

4	http://localhost:1494/api/admin/PutDealer?id=6 -	Update dealer information	

.Data{
"name": "HelloWorld",
"email": "Hello@testmail.com.au",
"address":  "Mulgrave Melbourne VIC"
}

5	http://localhost:1494/api/admin/DeleteDealer?id=6	 - Delete dealer infromation

# Car Controller for a Particular Dealer ID

1	http://localhost:1494/api/Car/GetAllCars/2 - Get all Cars for a particular dealer 

example DealerId = 2

2	http://localhost:1494/api/Car/PostCar - Insert a new Car stock for a particular dealer	

Content-Type: application/json

Cache-Control: no-cache

.data
{
"Id":"4",
"Year":"2012", 
" Make":"Chevrolet", 
 "Model":"Chevrolet Imapla", 
 "Badge":"ChevvyBadge", 
  "EngineSize":"TestChevvyEng", 
  "Transmission":"Petrol", 
   "Dealer" : {      "Id": "2",
                         "Name" : "Dealer1", 
                         "Email" : "dealer1@test.com", 
                         "Address" : "Fitzroy, Melbourne, VIC" 
                     }
}

3	http://localhost:1494/api/Car/PutCar?Id=3 - 	Update Car stock details of a particular Dealer	

4	http://localhost:1494/api/Car/DeleteCar?Id=3 - Delete a car of a particular dealer	

# Dealer Controller

1	http://localhost:1494/api/Dealer/PutDealer?id=6 -	Update dealer information	

.data{
"name": "HelloWorld",
"email": "Hello@testmail.com.au",
"address":  "Mulgrave Melbourne VIC"
}

2	http://localhost:1494/api/Dealer/GetStockSummary/3 - Stock Summary of a particular dealer	Created Today & Archive Data

# Search API

1	http://localhost:1494/api/Car/SearchAsync?Name=dealer -	Search by dealer name	HTTP Post

2	http://localhost:1494/api/Car/SearchAsync?Make=BMW&Year=2006 - Retrieves data by car information 

Example Make = BMW or Year = 2006

# Email Controller
			


