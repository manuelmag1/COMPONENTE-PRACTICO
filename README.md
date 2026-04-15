# Hot Rope Jump - Prototipo Digital

## Descripción
**Hot Rope Jump** es un minijuego de supervivencia competitiva multijugador local diseñado para hasta cuatro jugadores. Basado en el concepto de esquivar un peligro constante en un espacio cerrado, los jugadores deben saltar coordinadamente una cuerda giratoria compuesta por llamas de fuego llamadas "Podoboos". El objetivo principal es convertirse en el último jugador en pie. La experiencia ofrece un ritmo rápido y una tensión ascendente, poniendo a prueba los reflejos mediante el incremento dinámico de la velocidad del obstáculo.

## Instrucciones Básicas
1. **Selección de Personajes**: En la pantalla de selección, los jugadores deben unirse a la partida presionando su tecla asignada. El retrato del personaje cambiará de color para confirmar su disponibilidad.
2. **Inicio de Partida**: Una vez que al menos un jugador ha sido seleccionado, se debe presionar la barra espaciadora para cargar la escena de juego.
3. **Mecánica de Juego**:
    * Los jugadores deben saltar la cuerda de fuego justo antes de que toque sus pies.
    * El sistema detecta automáticamente si el personaje está en el suelo para permitir el salto.
    * Si un jugador es golpeado por un "Podoboo", se activará una secuencia de eliminación y el personaje quedará fuera de la ronda.
4. **Progresión de Dificultad**: La velocidad de rotación aumenta gradualmente cada 6 vueltas completadas. Al llegar a la vuelta 10, los fuegos cambian de color (de azul a amarillo) como alerta visual de peligro incrementado.
5. **Victoria**: La partida finaliza cuando solo queda un sobreviviente, quien es declarado ganador. En caso de que todos sean golpeados simultáneamente, se declara un empate.

## Controles
El juego utiliza un esquema de control compartido en el teclado para facilitar la competencia local:

| Jugador | Personaje | Selección / Salto |
| :--- | :--- | :--- |
| **P1** | Mario | Tecla `A` |
| **P2** | Wario | Tecla `V` |
| **P3** | Peach | Tecla `M` |
| **P4** | Kong | Tecla `L` |
| **Sistema** | Iniciar Juego | Tecla `Espacio` |

## Características Técnicas
* **Sistema de Audio**: Implementado mediante un patrón Singleton que gestiona canales separados para música en bucle y efectos de sonido (SFX) mediante `PlayOneShot`.
* **Físicas de Salto**: Utiliza componentes `Rigidbody` e impulsos verticales, con detección de suelo basada en `Physics.Raycast` para garantizar precisión.
* **Efectos Visuales**: Los obstáculos de fuego presentan un efecto de flotación orgánica mediante la función matemática `Mathf.Sin` y desfases aleatorios.
* **Lógica Global**: Un `GameManager` centralizado coordina la cuenta regresiva inicial, el conteo de jugadores vivos y las condiciones de victoria o empate.

---
*Desarrollado en Unity 3D utilizando C#.*
