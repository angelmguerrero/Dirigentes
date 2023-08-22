# client-app

## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Lints and fixes files
```
npm run lint
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).


INSTRUCCIONES PARA GENERAR EL COMPILADO DE PUBLICACIÓN 

PUBLICACIÓN API 


1. 
	ACTUALIZAR LOS VALORES DE LAS VARIABLES DEL ARCHIVO appsettings.json


2.  GENERAR LA PUBLICION CON LO SIGUIENTES PARAMETROS

	CONFIGURATION RELEASE 
	TARGET FRAMEWORK NET6.0
	TARGET RUNTIME WIN-X64


PUBLICACION DE UI

1.
	PARA EL DESPLIEGUE EN EL AMBIENTE DE QA  O PRD SE DEBE REALIZAR EL CAMBIO EN EL ARCHIVO 
	vue.config.js  
	LA VARIABLE publicPath: '/CPMPlataformadirigentesQA/' POR EL PATH DONDE SE VA A REALIZAR EL DESPLIEGE 
	SI SE DESPLIEGA EN RAIZ DEBE IR EN BLANCO

2. 
	EN EL ARCHIVO \CPM.PlataformaDirigentes\CPMPlataformaDirigentes\client-app\src\config\auth.js

	ACTUALIZAR LAS VARIABLES POR LOS VALORES CORRESPONDIENTRES A CADA AMBIENTE 
	const clientId = "105ad81b-e1f6-4bcb-a134-e9467f0ed8ab";
	const tenantId = "89500ceb-6aa4-4660-a1b5-f16ef59aea09";
	const redirectUri = "https://10.99.9.25/CPMPlataformadirigentes/login";



3.  
	COMPILAR EL UI 
	npm run build

	LOS ARCHIVOS GENERADOS EN LA CARPETA DIST SE DEBEN MOVER A LA CARPETA WWWROOT DE LA
	PUBLICACION DEL API 

