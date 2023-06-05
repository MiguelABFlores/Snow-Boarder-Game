# Snow-Boarder-Game

Simple Snow Board Game made in Unity 2021

#====================================================================================================
Linux Server Deployment steps:
#----------------------------------------------------------------------------------------------------
sudo apt update -y
sudo apt upgrade -y
sudo apt install net-tools -y
#====================================================================================================
Install Apache
https://www.digitalocean.com/community/tutorials/how-to-install-the-apache-web-server-on-ubuntu-22-04
#----------------------------------------------------------------------------------------------------
sudo apt install apache2 -y
sudo ufw app list
sudo ufw allow 'Apache'
sudo ufw status

sudo systemctl status apache2
hostname -I
curl -4 icanhazip.com

sudo mkdir /var/www/gameserver
sudo chown -R $USER:$USER /var/www/gameserver
sudo chmod -R 755 /var/www/gameserver

sudo vim /etc/apache2/sites-available/gameserver.conf
#----------------------------------------------------------------------------------------------------
<VirtualHost *:80>
    ServerAdmin miiguelb07@gmail.com
    ServerName gameserver
    ServerAlias www.gameserver
    DocumentRoot /var/www/WebGL_Game
    ErrorLog ${APACHE_LOG_DIR}/error.log
    CustomLog ${APACHE_LOG_DIR}/access.log combined
</VirtualHost>
#----------------------------------------------------------------------------------------------------
sudo vim /etc/apache2/apache2.conf
#----------------------------------------------------------------------------------------------------
ServerName gameserver

# -----------------------------------------------------------------------------
# This configuration file should be uploaded to the server as "<Application Folder>/Build/.htaccess"
# This configuration has been tested with Unity 2020.1 builds, hosted on Apache/2.4
# NOTE: "mod_mime" Apache module must be enabled for this configuration to work.
<IfModule mod_mime.c>

# The following lines are required for builds without decompression fallback, compressed with gzip
RemoveType .gz
AddEncoding gzip .gz
AddType application/octet-stream .data.gz
AddType application/wasm .wasm.gz
AddType application/javascript .js.gz
AddType application/octet-stream .symbols.json.gz

# The following lines are required for builds without decompression fallback, compressed with Brotli
RemoveType .br
RemoveLanguage .br
AddEncoding br .br
AddType application/octet-stream .data.br
AddType application/wasm .wasm.br
AddType application/javascript .js.br
AddType application/octet-stream .symbols.json.br

# The following line improves loading performance for uncompressed builds
AddType application/wasm .wasm

# Uncomment the following line to improve loading performance for gzip-compressed builds with decompression fallback
# AddEncoding gzip .unityweb

# Uncomment the following line to improve loading performance for brotli-compressed builds with decompression fallback
# AddEncoding br .unityweb
</IfModule>
# -----------------------------------------------------------------------------
#----------------------------------------------------------------------------------------------------

sudo a2ensite gameserver.conf
sudo a2dissite 000-default.conf
sudo apache2ctl configtest
sudo systemctl restart apache2