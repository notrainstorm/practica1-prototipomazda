# Mazda · Prototipo de aplicación de escritorio (WPF)

Práctica 1 de *Interfaces de Usuario* · Grado en Ingeniería Informática en Tecnologías de la Información · Universidad Miguel Hernández de Elche (UMH)

Autora: María Barberá Zaragoza · Noviembre de 2026

![Portada de la aplicación](img/captura.png)

## Descripción

Prototipo de una aplicación de escritorio para una tienda de venta de coches, desarrollado con Microsoft Blend y WPF a partir de los requisitos de un cliente. La aplicación simula la web de venta de una tienda Mazda, con el MX-5 como modelo destacado.

El enunciado plantea como cliente a Polestar. Se ha trabajado con Mazda por preferencia personal de la autora por el modelo MX-5.

Se trata de un prototipo: no existe base de datos ni servidor, y todo el comportamiento se simula en el cliente. El objetivo es evaluar la interfaz, la usabilidad y la navegación, no la lógica de negocio.

## Funcionalidades

- **Inicio.** Portada con el MX-5, su precio de partida (29.995 €) y un botón que lleva a su ficha.
- **Login / Sign up.** Formulario con pestañas animadas. La contraseña se oculta y dispone de un texto de ayuda. Se informa de los errores por campos vacíos y por credenciales incorrectas.
- **Galería.** Seis modelos de la gama en tarjetas: MX-5, CX-5, Mazda6, Mazda3, CX-30 y CX-60.
- **Ficha del MX-5.** Descripción, potencia, aceleración de 0 a 100 km/h, tracción y botón para solicitar una prueba.
- **Elementos comunes.** Barra superior con el logotipo y menú lateral desplegable (Inicio, Login, Galería y Salir), presentes en todas las pantallas.

## Requisitos y ejecución

- Windows con Visual Studio 2022 (o Microsoft Blend) y la carga de trabajo de desarrollo de escritorio de .NET.

Pasos:

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/notrainstorm/practica1-prototipomazda.git
   ```
2. Abrir el archivo de proyecto (`.csproj`) o la solución.
3. Ejecutar con **F5**.

Credenciales de prueba: usuario `Alumno`, contraseña `1234`. Están definidas en el código por tratarse de un prototipo; en una aplicación real la validación se realizaría contra un servidor.

## Estructura del proyecto

```
├── MainWindow.xaml        # Interfaz: pantallas, barra superior, menú, estilos y estados visuales
├── MainWindow.xaml.cs     # Lógica: navegación, validación del login y animaciones del menú
└── img/                   # Imágenes utilizadas por la aplicación y por este README
```

La aplicación es una única ventana de 1280 x 720 con dos filas: una de 80 píxeles para la barra superior y otra para las pantallas. Inicio, Login, Galería y la ficha del MX-5 son contenedores dentro de esa ventana, y solo uno es visible a la vez; el código modifica su propiedad `Visibility`. De este modo, la barra y el menú no se repiten y mantienen siempre la misma posición.

## Decisiones de diseño

- **Consistencia.** Misma paleta (azul oscuro `#041428`, blanco y grises) y mismos botones en todas las pantallas.
- **Jerarquía visual.** Títulos y precios en negrita y de mayor tamaño; descripciones en gris y menor tamaño.
- **Prevención y gestión de errores.** El login distingue entre campos vacíos y credenciales incorrectas, y devuelve el foco al campo de usuario.
- **Feedback.** Mensajes al iniciar sesión, solicitar una prueba o recuperar la contraseña; cursor de mano en los elementos pulsables; la pestaña activa del login cambia de color y de grosor.
- **Accesibilidad.** Contraste alto del texto blanco sobre azul oscuro y tamaño de letra mínimo de 11 puntos. Queda pendiente añadir propiedades para lectores de pantalla.
- **Animaciones.** Solo dos, de corta duración: el deslizamiento del menú lateral (0,25 s al abrir y 0,20 s al cerrar) y el desplazamiento de la línea de pestañas del login (0,25 s).

La justificación completa se encuentra en la documentación técnica entregada junto con el proyecto.

## Pruebas y mejoras

Se comprobaron manualmente los siguientes casos, todos con resultado correcto: login con campos vacíos, con datos incorrectos y con datos correctos; ocultación de la contraseña y desaparición de la etiqueta al escribir; cambio entre las pestañas Login y Sign up; apertura y cierre repetido del menú; navegación por el menú y acceso a la ficha del MX-5; solicitud de prueba y salida de la aplicación.

Problemas encontrados durante el desarrollo y su resolución:

- **Texto de ayuda en la contraseña.** El control `PasswordBox` no dispone de propiedad `Text`. Se resolvió superponiendo un `TextBlock` con `IsHitTestVisible="False"` y ocultándolo desde el evento `PasswordChanged` cuando el campo tiene contenido.
- **Animación del menú lateral.** Los estados grabados en Blend producían tirones y el panel no aparecía al animarlo solo por código. Se ajustaron el XAML de `MenuLateral` y los métodos `AbrirLateral` y `CerrarLateral`.
- **Tamaño de las imágenes.** Varias fotos tenían proporciones distintas y se veían recortadas o deformadas. Se reescalaron a un tamaño y una proporción uniformes.

Limitaciones conocidas, pendientes como mejora:

- El campo de usuario muestra el texto «Email», pero el login espera «Alumno». Además, ese texto es contenido real del campo y no una etiqueta que desaparece.
- Las tarjetas de la galería distintas del MX-5 muestran el cursor de mano pero no ejecutan ninguna acción.
- La pestaña Sign up solo cambia el aspecto del formulario; no realiza ningún registro.
- Faltan propiedades de accesibilidad para lectores de pantalla.

## Recursos utilizados

| Recurso | Uso | Procedencia y licencia |
|---|---|---|
| Imágenes de modelos y portada (`img/`) | Inicio, galería y ficha | Web oficial de Mazda; [Top Gear](https://www.topgear.com/long-term-car-reviews/mazda/mx-5/20-184-homura-2dr/report-1); [PistonHeads](https://www.pistonheads.com/news/ph-driven/mazda-mx-5-vs-toyota-gr-yaris-vs-ariel-nomad/49756). Propiedad de sus autores y de Mazda; uso exclusivamente educativo |
| Logotipos y fondo del login | Barra superior y login | Web oficial de Mazda. Uso exclusivamente educativo |
| Tipografía | Toda la interfaz | Por defecto de WPF (Segoe UI) |
| Estilo `BotónLateral` | Botones sin efecto al pasar el ratón | Generado con Blend a partir de la plantilla estándar de WPF y modificado manualmente |
| Paleta de colores | Diseño de la interfaz |

No se ha utilizado ninguna biblioteca externa.

## Documentación

La documentación técnica completa (requisitos, arquitectura, justificación del diseño, pruebas, recursos y uso de IA) se incluye en `Documentacion.pdf`.
