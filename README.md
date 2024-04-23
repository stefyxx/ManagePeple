_Test For IONIX_ : Web service REST/Json permettant de gérer des personnes dans un DB

## Choices

First of all, in my DB I have a single table that I need to manage; for this I figured it wasn't necessary to create asynchronous functions in my 

    ManagePeople.BLL/Services/PersonServices

Then, into my ManagePeople.BLL/Services/PersonServices I have two functions: 'Update' and 'Delete'  that each make two calls to the DB, since two instances are not so excessive, I considered it unnecessary to use

    using TransactionScope scope = new TransactionScope(); 
    ...
    scope.Complete();

to 'force' the Destroy to clean everything just before the return



