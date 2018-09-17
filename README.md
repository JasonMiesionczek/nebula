Nebula
======

Project
-------
Nebula is designed to work within a project setting. The CLI tool can create and manage these projects. 

Layout
------
* project folder
    * out
    * src
        * models
        * apis
        * exceptions
    * templates
    * docs
    * tests

**out** - library output for each configured language/framework

**src** - root folder for storing the code for your APIs and data models

**templates** - boilerplate files for each language/framework

**docs** - API documentation that is dynamically generated for each language/framework

**tests** - automatically generated and manually written unit and integration tests

Projects are created by cloning the project skeleton and updating the nebula.json file found within.

Language
--------
Each folder under src/ becomes a root module. Sub directories become sub modules. There are several top-level constructs that are available:
* model
* api
* function
* exception

and several data types:
* string
* boolean
* integer
* float
* double
* char
* array
* datetime

keywords:
* model
* api
* func
* exception
* export
* use
* config

Model example (Product.neb):
```
export entity Proudct {
    name: string,
    price: double,
    quantity: integer,
    clearance: boolean,
    description: string,
    priceHistory: array[PriceHistory]
}

entity PriceHistory {
    date: datetime,
    price: double
}
```

API example:
```
use model.Product

api ProductService {
    config {
        host = "https://someapi.somedomain.com"
        prefix = "/api"
    }

    // GET style API calls
    // 1.         2. 3.        4. 5.             6. 7.
    func getProducts() << /products -> array[Product] :: SomeException

    func getProductById(id: integer) << /product/{id} -> Product

    // POST style API calls
    func createProduct(id: integer, p: Product) >> /product/{id} -> boolean

    // PUT style API calls
    func updateProduct(id: integer, p: Product) >| /product/{id} -> boolean

    // DELETE style API calls
    func deleteProduct(id: integer) >X /product/{id} -> boolean
}
```

1. name of function to generate, including any specified parameters
2. Symbol denoting the HTTTP Method to use
    * `<<` = GET
    * `>>` = POST
    * `>|` = PUT
    * `>X` = DELETE
3. URL to use
4. Symbol indicating return data type
5. return data type
6. Symbol denoting this function can throw exceptions
7. List of exceptions

Templates
---------
Templates are where the bulk of the work is handled. All of the boiler plate code for performing the HTTP requests, and serializing/deserializing objects is handled in the template. A template can be associated with both a language and a framework. This is to allow integration with different frameworks easy so that developers can focus on their business logic, not how to get the client to work with their stack of choice.

Templates will be stored locally on the workstation, and the CLI tool can check for new and updated templates. Installing a new template will be a matter of cloning its repository, and updating it will simply be a fetch and pull. This system will allow for templates to be modified locally, and upon update any conflicts can be resolved by the user. 

A manifest file will be stored in a separate git repo, which is updated first during the update process. This manifest will contain the meta data about each template and is also stored locally. It will be from this manifest file that the list of templates will be pulled from when requested by the CLI.

A local configuration file will exist that points to the location of this manifest file. By using git repos we avoid having to build an API server which would over complicate things.