# Cocus file reader
Cocus Challenge - Exercise 3

WEB API for reading files from repository.
The git usage in this exercise took into consideration the usage of feature branches, which were merged into master. The master was inicialized with a "skeleton architecture" that consisted in the setup for the controllers.

The encryption requirements were implemented through the application of a strategy pattern, in which the adapter and the encryption key are defined in the appconfig.json of the application. Currently, only the XorStrategy is supported.

Similar to the encryption requirements, the user roles were implemented through a strategy patters, and the setup of the mock of the logged profile is defined in the appconfig.json, as well as the roles per feature.

A simple Authentication module was implemented from mock, although the application can easily be extended for data base presistance.

It's worth noticing that the setup for the encryption as well as the maximum number of files permited for the user role can be setup in the appsettings.json file.

Thanks for the challenge. It was fun.
