Welcome to the Quote Generator API!

For this project to run, you will need to have Postman open.

To start off, you will need to post an account to the API, which will need an email, password, and you will need to confirm the password as well. All of this should be done in the body, with urlencoded as the format. Make sure Postman is set to **POST** when you do this. Click Send and you should see 200 OK returned to you.

After you have posted your account, check to see if it is in the database. If the account has shown up in the database, you will need to put in https://localhost:xxxxx/token, put in your user info, and then the grant type. Make sure the function in postman is set to **GET** and your auth token will be displayed to you. 

**For all further functionality, you will need to put in an "Authorization" header tag, the content of it being "Bearer {your token here}".**

Let's start off with posting an author. To post an author, make sure your program is running (it will need to run for any other functions as well), set the function in Postman to **POST**, and in the form urlencoded section, you will need a name and date of birth (BirthDate). Once that has been inputted, hit send and you should receive a 200 OK. To test it has been put into the database, change the function to **GET**, uncheck the boxes in the body, and hit send. Your author should be returned to you. We will use this same testing function for Categories and Quotes as well. 

Before we can post a quote we will need to post a category to assign the quote to. Change the api to /api/Category and set the function to **POST**. For a category, you will only need a name for the category inside of the body. Hit send, and you should see a 200 OK. Go ahead and switch the function to **GET**, uncheck the box in the body, hit send, and your category should be returned to you. 

Now we can post a quote. Change over to /api/Quote, switch the function to **POST**. For this you will need the content(the quote itself), the author Id(can be found inside of your author datatable in VSCommunity), the category Id(also found in your category datatable), and the date that the quote was spoken. Once you hit send, you should see a 200 OK. Go ahead and change to **GET**, uncheck the boxes in body, hit send, and you should have your quote displayed to you. 

You can edit quotes, authors, and categories as well. To do so, change the function in Postman to **PUT**, and at the end of your server code, put /api/{your method here}. For this you will need to put in the Id of whatever the quote, author, category you want to update is, and then just like when you posted the information, you will need all of the same required fields as well. 

To delete any of the information in your datatables, change the function in Postman do **DELETE**, and at the end of your link, you will need to put the Id of the piece of information you are wanting to delete. (ex. http://localhost:xxxxx/api/Quote/1) Once you hit send, you should see a 200 OK, and you can check inside of your data tables to make sure it is no longer there.

For our **GET** functions, you can also get something by the Id of the object itself. Say the author of a quote is  Albert Einstein, and in the datatable, he has an Id of 4. All I have to do is put in my link, and at the end of the **GET** author function in the link, put /4.  Einstein and all of the information pertaining to him should be displayed. This works the same way for our all of our get by Id methods. 

We also have a function to get quotes randomly. To do this, in the link bar in Postman(Postman should be set to **GET**), out /api/Quote/ByRandom and hit send. You might get the same quote a few times, but that's just because it pulls a random quote.

You can also get quotes from a certain author. To do so, set Postman to **GET**, and at the end add /api/Quote/ByAuthor/{id here}. Hit send and you should receive all quotes from the author that has that Id tied to it. This also works with categories as well, just change the link to /api/Quote/ByCategory/{id here}.

We have a rating system built in for quotes as well. Change the Postman function to **POST**, change the link to /api/UserRatingQuote. The required fields you will need are the Id of the quote, the UserId(name), and UserRating which will be a decimal number. If there is multiple ratings for a quote, the scores are automatically averaged. 

To get all of the ratings that have been posted, change the Postman method to **GET**, put /api/Category/Ratings, and hit send. You do not need anything in the body. Once you hit send, a list of all quotes and their respective ratings should be displayed on the screen. 

There is a function for getting the best category, which would be the category that has the most rated quotes. For this, set Postman to **GET**, put at the end of the link to /api/Category/GetBestCategory and when you hit send the most rated category Id should be returned to you. 

Thank you for using the Quote Generator API!

-Made by Aaron Berberich, Josh Piersimoni, and Peyton Cooper.


**REFERENCES**

**PLANNING**
Trello board: https://trello.com/b/i9Ih0TkM/quotegeneratorapi

Google Doc with out layout and database info for presentation: https://docs.google.com/spreadsheets/d/1GUI66kxYbg8zZctbR1eWO0aRYdgFG0XaOhAvqP4GQhg/edit#gid=0

**QUOTES**
Humor Quotes: https://www.keepinspiring.me/funny-quotes/

Love Quotes: https://www.goodhousekeeping.com/life/relationships/g3721/quotes-about-love/

Motivational Qoutes: https://www.success.com/17-motivational-quotes-to-inspire-you-to-be-successful/

Intellectual Quotes: https://www.goodreads.com/quotes/tag/intellectual

**LEARNING**

Get index of item in a list: https://stackoverflow.com/questions/17264281/get-the-index-of-item-in-a-list-given-its-property

Extending IdentityUser with a custom property: https://stackoverflow.com/questions/40532987/how-to-extend-identityuser-with-custom-property/40579369

Multiple Http **GET** methods in web API controller: https://stackoverflow.com/questions/11407267/multiple-httppost-method-in-web-api-controller

Multiple Http **POST** methods in web Api controller: https://stackoverflow.com/questions/9499794/single-controller-with-multiple-get-methods-in-asp-net-web-api#:~:text=With%20the%20newer%20Web%20Api,to%20have%20multiple%20get%20methods.&text=Another%20options%20is%20to%20give%20the%20GET%20methods%20different%20routes

Application user as a foreign key: https://entityframework.net/knowledge-base/19936433/asp-net-mvc-5-identity-application-user-as-foreign-key

https://entityframework.net/knowledge-base/19936433/asp-net-mvc-5-identity-application-user-as-foreign-key









