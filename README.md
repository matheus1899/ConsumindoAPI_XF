# ConsumindoAPI_XF

<h3>Instale o npm</h3>
https://www.npmjs.com/get-npm

<h3>Após a instalação...</h3>

<b>Windows</b> + <b>R</b></br>
Digite <b>"cmd"</b> e dê Enter</br>
Digite <b>"npm"</b> e dê Enter</br>
Digite <b>"npm install -g json-server"</b></br>

[JSON Server](https://github.com/typicode/json-server) é um FakeServer, que 
serve para simular uma API REST</br>e que utiliza um arquivo <b>JSON</b> para simular o banco de dados</br>


<h3>Espere a instalação finalizar</h3>

Depois de instalado</br>
Digite no CMD <b>"npm"</b></br>
Em seguida digite o seguinte comando:</br>

<h4><b>"json-server --host ip_da_sua_maquina --watch Documents\db.json"</b></h4>

<b>--host</b> irá definir onde a API será "hospedada".</br>
Recomendo usar o <b>IPv4</b> de sua maquina, </br>só assim será acessível a 
outros computadores na mesma rede.
A API será acessada pelo link:<br>
http://seuip:3000/
 
<b>--watch</b> será a localização do seu arquivo json</br>
que servirá de base para simular uma API com DB.<br/>
Use a tecla <b>TAB→←</b> para autocompletar o diretorio.


Mas caso você queira usar o servidor apenas no seu </br>
computador basta digitar esse comando no lugar do anterior:</br></br>
<b>"json-server --watch Documents\db.json"</b>

Já neste caso, sua API será acessada pelo link:<br>
http://localhost:3000/

<b>Tutorial JSON-Server →</b> https://www.fabricadecodigo.com/json-server/
