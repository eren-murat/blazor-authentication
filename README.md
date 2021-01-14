# blazor-app

## IIS Manager Configurations
    * application pools -> advanced settings
                        * identity -> custom account
                        * load user profile -> *true*
    * default web site -> authentication -> basic authentication -> *true* (set the rest to false)
    * default web site -> configuration editor -> section -> system.webServer/security/authentication/windowsAuthentication
                        * useAppPoolCredential -> *true*
    * default web site -> basic settings -> connect as -> application user (pass-through authentication)
