#### Installation

```
sudo apt-get update
sudo apt-get upgrade
sudo apt-get install squirrelmail
```

#### Configure the Virtual Host

```
sudo cp /etc/squirrelmail/apache.conf /etc/apache2/sites-available/squirrelmail.conf
```

```
Alias /squirrelmail /usr/share/squirrelmail

<Directory /usr/share/squirrelmail>
  Options FollowSymLinks
  <IfModule mod_php5.c>
    php_flag register_globals off
  </IfModule>
  <IfModule mod_dir.c>
    DirectoryIndex index.php
  </IfModule>

  # access to configtest is limited by default to prevent information leak
  <Files configtest.php>
    order deny,allow
    deny from all
    allow from 127.0.0.1
  </Files>
</Directory>

# users will prefer a simple URL like http://webmail.example.com
<VirtualHost *:80>
  DocumentRoot /usr/share/squirrelmail
  ServerName mail.lokaverkefni.tk
</VirtualHost>

# redirect to https when available (thanks omen@descolada.dartmouth.edu)
#
#  Note: There are multiple ways to do this, and which one is suitable for
#  your site's configuration depends. Consult the apache documentation if
#  you're unsure, as this example might not work everywhere.
#
#<IfModule mod_rewrite.c>
#  <IfModule mod_ssl.c>
#    <Location /squirrelmail>
#      RewriteEngine on
#      RewriteCond %{HTTPS} !^on$ [NC]
#      RewriteRule . https://%{HTTP_HOST}%{REQUEST_URI}  [L]
#    </Location>
#  </IfModule>
#</IfModule>
```

#### Enable the new virtual host

```
sudo a2ensite squirrelmail.conf
```

#### Reload Apache

```
sudo systemctl reload apache2.service
```

#### Configure SquirrelMail

```
sudo squirrelmail-configure
```
> Fix the domain by hittin 2 and then 1 and change domain name to "Lokaverkenfi.tk"
