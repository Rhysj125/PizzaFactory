The solution has been broken down in to multiple projects, following DDD and clean architecture.

The Console project is responsible only for creating the applciation. This requires some configuration such as registering its dependancies with the .NET DI container. The projects that required registering have extension methods on IServiceCollection
in order to set themselves up correctly. 

The Core project deals with most of the system logic. There is a GeneratePizzasUseCase which orchestrates everything. This use cases requires an IPizzaRepository, IPizzaFactory and CoreConfiguration which uses the options pattern. 
The IPizzaFactory is used to a number of pizzas, which also uses CoreConfiguration to get this from a JSON file. The IPizzaRepository is used only for saving a Pizza. This happens once it has been cooked. This use case has two implementation of the execute
method, Execute and ExecuteAsync. The Async option does not wait for a pizza to finish cooking before another starts cooking. It will start cooking a pizza after a fix interval no matter what. Whereas the non async option will wait until the pizza has 
finished cooking and then waiting again for the set interval before starting to cook another pizza. I did this due to some confusion with the wording of the given task so implemented both. All the dependancies for the Core project are registered inside
the CoreConfigure. This adds the GeneratePizzasUseCase and PizzaFactory to the DI container and adds a CoreSettings.json file and configures it for use with the Options Pattern.

The Infrastructure implements the IPizzaRepository from the Core project which saves the descriptions of a pizza to a file. The InfrastructureConfigurer works similar to the CoreConfigure where it registers the IPizzaRepository with it's 
implementation of FilePizzaRepository and adds a InfrastructureSettings.json and configures it. This file contains the configuration for the location and file name that the FilePizzaRepository uses.

The Domain holds the domain objects for the system such as PizzaBase, Topping and a Pizza. A Topping has only a Name, a PizzaBase a Name and a CookingMultiplier and a Pizza comprises of a PizzaBase and a Topping. The cooking time for a topping is calculated
within its own class which is then used inside of the pizza which has a Cook method. This cook method takes a base cooking time which then gets multiplied by the PizzaBase CookingMultiplier before adding the topping cook times.