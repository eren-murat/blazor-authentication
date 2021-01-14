# blazor-app

## IIS Manager Configurations
   - application pools
     - advanced settings
       - identity -> ApplicationPoolIdentity
         - load user profile -> *true*
   - default web site
     - authentication
       - basic authentication -> *true* (set the rest to false)
     - configuration editor
       - section
         - system.webServer/security/authentication/windowsAuthentication
           - useAppPoolCredential -> *true*
     - basic settings
       - connect as
         - application user (pass-through authentication)
