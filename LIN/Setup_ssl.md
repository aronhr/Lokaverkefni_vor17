## Set up SSL for server

#### I add reporitory
  > sudo add-apt-repository ppa:certbot/certbot
  
#### Update modules
  > sudo apt-get update
  
#### Intall certbot
  > sudo apt-get install python-certbot-apache
  
#### Gather certificate from Certbot
  > sudo certbot --apache -d lokaverkefni.tk
  > I always get error code from that specific command
  > The error was: PluginError('There has been an error in parsing the file /etc/apache2/sites-available/html.conf.save on line 28: Syntax error',)
  > Ive tried everything. I took a look on the web and tried editing config files but with no luck
