# distributed key-value & config store

## motivation

As an application stands up, as you all know, it is always based on a configuration file.This file contains all the data that we expect to be variable, sensitive and confidential for that application.In this project, we will examine how we have purified our dotnet core application from all the configuration information in a distributed, concurrent way.

### ttl

coming soon...

### key versioning

### service discovery
coming soon...
 
this state is important if any node fails which exists in cluster then
can make to leader election because , this is best practices that shouldn't  be edit app bundle by runtime.And if It is saving and open plain key in config file , might not be secure for app.
If any key persists in config file , when hackers get in the server and they can scan filesystems.

## how it works


## references 