#### Create new user called Aron
```
  adduser Aron
  adduser Adam
  adduser Eddi
```
#### Create new group called users
```
  groupadd users
```
#### Add users to the group
```
  usermod -a -G users Aron
  usermod -a -G users Eddi
  usermod -a -G users Adam
```
#### Make group permission to modify /var/www/html folder
```
  chgrp users /var/Www/html
  chmod g+rwx /var/www/html
  chmod g+s /var/www/html
```
