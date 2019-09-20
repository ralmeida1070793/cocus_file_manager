# Cocus file reader
Cocus Challenge - Exercise 3

WEB API for reading files from repository.
The git usage in this exercise took into consideration the usage of feature branches, which were merged into master. The master was inicialized with a "skeleton architecture" that consisted in the setup for the controllers.

The encryption requirements were implemented through the application of a strategy pattern, in which the adapter and the encryption key are defined in the appconfig.json of the application. Currently, only the XorStrategy is supported.

Similar to the encryption requirements, the user roles were implemented through a strategy patters, and the setup of the mock of the logged profile is defined in the appconfig.json, as well as the roles per feature.
