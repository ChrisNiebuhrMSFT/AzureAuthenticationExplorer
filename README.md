# Azure Authentication Explorer
This tool helps to understand the Azure Authentication Process a bit better.  
Just provide the Informations from your Azure App-Registration: 

* Client-ID  
* Tenant-ID  
* Redirect-Uri

![AAE1](/AzureAuthenticationExplorerUI/AzureAuthenticationExplorerUI/Assets/AAE_1.png)


After you've provided the information you can select a Sign-in Method.  
* Interactive  
* Silently => This will only work if the Tool finds a Token-Cache Data File otherwise  
you will be asked to login interactively instead.   

![AAE2](/AzureAuthenticationExplorerUI/AzureAuthenticationExplorerUI/Assets/AAE_2.png)    

Follow the Login-Wizard:    

![AAE3](/AzureAuthenticationExplorerUI/AzureAuthenticationExplorerUI/Assets/AAE_3.png)    

After the login you can see the Authenticationtoken on the left-hand side.  
On the right-hand side you will see the readable Version of the JWT (JSON Web Token).  
Here you can examine all the neccessary Informations you are interested in.  
The Scope (permissions) the token gives you for example.     

![AAE4](/AzureAuthenticationExplorerUI/AzureAuthenticationExplorerUI/Assets/AAE_4.png)    

From now on you can either use the Silent Logon or you can Sign out und Sign in with another account or against another App-Registration.   
Enjoy!

