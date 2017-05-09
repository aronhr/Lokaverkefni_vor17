## Set up SSL for server

#### Add repository
  ` > sudo add-apt-repository ppa:certbot/certbot`
  
#### Update modules
  ` > sudo apt-get update`
  
#### Intall certbot
  ` > sudo apt-get install python-certbot-apache`
  
#### Gather certificate from Certbot
  ` > sudo certbot --apache -d lokaverkefni.tk`
  
I always get error code from that specific command. `The error was: PluginError('There has been an error in parsing the file /etc/apache2/sites-available/html.conf.save on line 28: Syntax error',)`.
Ive tried everything. I took a look on the web and tried editing config files but with no luck

#### Trying to fix
I tried editing /etc/apache2/sites-available/html.conf.save and deleted </VirtualHost> since that was giving the Syntax error.
After that I got another error "Can’t renew certificate: We were unable to find a vhost with a ServerName or Address". I had to go into 000-default.conf and add ServerName lokaverkefni.tk and ServerAlias www.lokaverkefni.tk and everything went smoothly after that.
  
#### You have an excisting certificate that has exactly the same domains and certficiate name you requested and isn't close to expiry.
  > 1. Attempt to reinstall this existing certificate.
  > 2. Renew and replace the cert (limit ~5 per 7 days)
This happend because I just made a cerificate but got an error in the command after.
  
  ` > 1`

  
#### HTTPS required or optional
  > 1. Easy - Allow both HTTP and HTTPS access to these sites
  > 2. Secure - Make all requests redirect to secure HTTPS access

  ` > 2`
  
