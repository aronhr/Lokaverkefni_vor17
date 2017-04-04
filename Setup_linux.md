## Setup Linux server, mysql and https

#### Update server and install apache2

```
  sudo apt-get update
  sudo apt-get install apache2
```

#### Set Global ServerName to Suppress Syntax Warnings

```
sudo apache2ctl configtest
```
> Syntax OK

#### Setup an domain to access the database.

```
sudo chmod -R 755 /var/www
```

#### Create Virtual Host File

```
sudo cp /etc/apache2/sites-available/000-default.conf /etc/apache2/sites-available/html.conf
```

#### Change ServerAdmin, ServerName and ServerAlias

```
 sudo nano /etc/apache2/sites-available/html.conf
```

>  ServerName lokaverkenfi.tk

>  ServerAlias www.lokaverkefni.tk

>  ServerAdmin admin@lokaverkefn.tk

>  DocumentRoot /var/www/html

#### Enable the New Virtual Host Files

```
 sudo a2ensite html.conf
```

> To activate the new configuration, you need to run: service apache2 reload

```
 service apache2 reload
```
