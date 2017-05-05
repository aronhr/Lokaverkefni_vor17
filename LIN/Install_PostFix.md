#### Intall PostFix

```
sudo apt-get update
sudo DEBIAN_PRIORITY=low apt-get install postfix
```

##### Then i was asked questions and i answered them like this.

```
General type of mail configuration?: Internet Site
System mail name: lokaverkefni.tk
Root and postmaster mail recipient: lokaverkefni
Other destinations to accept mail for: $myhostname, lokaverkefni.tk, mail.example.com, localhost.example.com, localhost
Force synchronous updates on mail queue?: No
Local networks: 127.0.0.0/8 [::ffff:127.0.0.0]/104 [::1]/128
Mailbox size limit: 0
Local address extension character: +
Internet protocols to use: ipv4
```

#### Configure postfix

```
sudo postconf -e 'home_mailbox= Maildir/'
```
##### Set up the virtual maps file

```
sudo nano /etc/postfix/virtual
```
###### Added admin and contact email

```
contact@lokaverkefni.tk Lokaverkenfi
admin@lokaverkefni.tk Lokaverkenfi
```

###### Apply the mapping

```
sudo postmap /etc/postfix/virtual
```

######  Restart the Postfix

```
sudo systemctl restart postfix
```

#### Adjust the Firewall

###### Allow connections to the service

```
sudo ufw allow Postfix
```

#### Setting up the Environment to Match the Mail Location

```
echo 'export MAIL=~/Maildir' | sudo tee -a /etc/bash.bashrc | sudo tee -a /etc/profile.d/mail.sh
```
#### Install and Configure the Mail Client

```
sudo apt-get install s-nail
```

###### Change some setting is s-nail.rc

```
sudo nano /etc/s-nail.rc
```
###### Add these in the file

```
set emptystart
set folder=Maildir
set record=+sent
```
