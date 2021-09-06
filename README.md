#Examen practico Quark, Cotizador


- El proyecto se realizo como una aplicación de Windows Forms .net.
- El código fuente y todos sus archivos se encuentran en https://github.com/geruman/examen_practico_quark/
- El Diagrama de clases se encuentra en https://github.com/geruman/examen_practico_quark/blob/master/Diagrama%20de%20Clases%20Examen%20Practico%20Quark.png
- Un ejecutable(.exe) puede encontrarse en el siguiente link https://github.com/geruman/examen_practico_quark/blob/master/CotizadorQuarkExamen/bin/Debug/CotizadorQuarkExamen.exe


El diagrama de clases esta modelado separando los atributos de las propiedades, me parecio más legible aunque luego en el código la mayoría se codificaron directamente 
como Propiedades(con get;set; o get; private set;)

##Sobre la codificación del proyecto.


Se útilizo un windows form compuesto de distintos componentes llamado Form1,
El código comienza en Program.cs donde se crean las instancias del modelo incluyendo Tienda, Vendedor y las distintas Prendas, Luego se crea un ViewController y un Form1.
Form1 implementa una interfaz IMainView, a su vez, se le asigna una referencia al ViewController, y a viewController se le pasa la instancia de Form1 (De la cual conoce
solo la interfaz implementada IMainView, no el funcionamiento interno)
Luego Form1, reacciona contra los eventos de usuarios y llama directamente a metodos del viewController, el viewController habla contra el modelo (Del cual también tiene 
una referencia a travez del objeto tienda creado anteriormente) Y luego llama a métodos implementados de la interfaz IMainView.

##Sobre el uso de la aplicación.
Cuando se ejecuta el programa, tanto la tienda como el vendedor están autogenerados y solo puede usarse un vendedor, las prendas también estan creadas de antemano.
Pueden seleccionarse los parametros para la cotización y llenar los valores de precio unitario y cantidad.
Al darle click al boton Cotizar, se cotizara la prenda con los parametros actuales y el mismo se agregara al historial de cotizaciones (Al cual puede accederse
mediante el tabbed pane "Historial de cotizaciones".
Actualmente no hay forma de generar una venta por lo que las unidades en stock nunca disminuyen, pero puede probarse que la cotización funcione correctamente
poniendo una cantidad mayor a las unidades en stock disponibles.