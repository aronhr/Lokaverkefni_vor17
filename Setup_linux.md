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

>  ServerName lokaverkefni.tk

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

#### Setup mysql and phpmyadmin

```
 	sudo apt-get update
	sudo apt-get install phpmyadmin php-mbstring php-gettext
```
> Then we need to enable mcrypt and mbstring

```
 	phpenmod mcrypt
	phpenmod mbstring
```

> Then we need to restart apache

```
 	systemctl restart apache2
```


##### I got an error with Mysql setup

> #2002 - No such file or directory<br />The server is not responding (or the local server's socket is not correctly configured).

##### I need to purge mysql and reinstall it!
##### I will follow my previous steps. When i am done removing mysql.

#### Purge phpmyadmin

```
	sudo apt-get purge phpmyadmin
```

##### The solution to the problem was, i forgot to install mysql.

```
sudo apt-get install mysql-server
```
> Everything it up and running!

### Allow remote connection to mysql-server

```
sudo nano /etc/mysql/mysql.conf.d/mysqld.conf
```

> Find bind-address = 127.0.0.1 and Change the address to wildcard 0.0.0.0
> This should look like this: bind-address = 0.0.0.0

##### Then restart mysql

```
service mysql restart
```

##### Then check if ip address is correct and is binding to correct port

```
netstat -plutn | grep -i sql
```
##### The output should look like this!
> tcp        0      0 0.0.0.0:3306            0.0.0.0:*               LISTEN      22228/mysqld
