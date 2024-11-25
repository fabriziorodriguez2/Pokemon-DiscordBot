<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

### Qué desafíos de la entrega fueron los más difíciles

Lo que más se nos dificultó fue adaptarnos al uso del bot, ya que tenía un formato bastante distinto al que estábamos acostumbrado y había que realizar ciertos cambios al código que ya teníamos y añadir algunas cosas de las que no estabamos del todo conscientes. Después de que supimos cómo utilizarlo en general, armar los comandos se nos hizo bastante más sencillo (sacando alguno en específico que se nos dificultó más). 

### Qué cosas aprendieron enfrentándose al proyecto que no aprendieron en clase como parte de la currícula

Al momento de unificar nuestro codigo con el codigo del bot teniamos el problema de que muchas de nuestras clases no eran compatibles con las implementadas por el bot, las clases Menu y Batalla. Al comprender el problema decidimos aplicar el patron Adapter, esto nos ayudo a que el codigo siguiera funcionando sin tener que realizar ningun cambio en nuestro codigo. Luego de utilizar este patron nos dimos cuenta de que muy probablemente volveremos a utilizar este patron en un trabajo, ya que, por ejemplo al momento de hacer una funcionalidad para una aplicacion, y querer añadirla a otra amabas aplicacion tendran diferentes codigos de funcionamiento, por lo que no será viable modificar el codigo para cada aplicacion, en lugar de eso implementaremos Adapter.
Otro patron de diseño que implementamos fue Strategy. Al momento de hacer los test nos topamos con el problema de que el daño de los ataques funcionaba de forma random, por lo que al momento de testear no sabiamos si el ataque seria critico o no. Decidimos hacer uso de strategy para verificar el codigo con los tests. Al hacer esto pudimos evitar errores al momento de saber el daño que causa un ataque a otro pokemon.


### Qué recursos (páginas web, libros, foros, etc) encontraron que les fueron valiosos para sortear los desafíos que encontraron
Principalmente, youtube, materiales de clase y el sitio web https://refactoring.guru/es
Strategy: https://refactoring.guru/es/design-patterns/strategy
Adapter: https://refactoring.guru/design-patterns/adapter
OCP: https://www.youtube.com/watch?v=ViKWVjyMUwQ

### Y cualquier otro tipo de reflexión, material o comentarios sobre el trabajo en el proyecto.

El ejercicio de trabajar en equipo para este proyecto esta muy bueno, ya que nos acerca a la vida laboral y a como colaborar con tus compañeros y llegar a acuerdos para soluconar diferentes problemas, a escuchar las ideas de los demas y a dividir las tareas equitativamente.
Disfrutamos de la modalidad del curso, fue a través de lo que se va aprendiendo en clase y de pequeños trabajos más chicos que pudimos armar algo más grande que incluso involucra una aplicación como lo es discord en este caso, de esta manera no solo aprendiendo más de C# sino también de cómo crear un bot de discord. Además pudimos reafirmar los conceptos de SOLID y GRASP.
