# [cite_start]Hot Rope Jump - Prototipo Digital [cite: 11]

## Descripción
[cite_start]**Hot Rope Jump** es un minijuego de supervivencia competitiva multijugador local diseñado para hasta cuatro jugadores[cite: 11]. [cite_start]Basado en el concepto de esquivar un peligro constante en un espacio cerrado, los jugadores deben saltar coordinadamente una cuerda giratoria compuesta por llamas de fuego llamadas "Podoboos"[cite: 11, 10]. [cite_start]El objetivo principal es convertirse en el último jugador en pie[cite: 11, 8]. [cite_start]La experiencia ofrece un ritmo rápido y una tensión ascendente, poniendo a prueba los reflejos mediante el incremento dinámico de la velocidad del obstáculo[cite: 11, 10].

## Instrucciones Básicas
1. [cite_start]**Selección de Personajes**: En la pantalla de selección, los jugadores deben unirse a la partida presionando su tecla asignada[cite: 5]. [cite_start]El retrato del personaje cambiará de color para confirmar su disponibilidad[cite: 5].
2. [cite_start]**Inicio de Partida**: Una vez que al menos un jugador ha sido seleccionado, se debe presionar la barra espaciadora para cargar la escena de juego[cite: 5, 8].
3. **Mecánica de Juego**:
    * [cite_start]Los jugadores deben saltar la cuerda de fuego justo antes de que toque sus pies[cite: 9, 10].
    * [cite_start]El sistema detecta automáticamente si el personaje está en el suelo para permitir el salto[cite: 9].
    * [cite_start]Si un jugador es golpeado por un "Podoboo", se activará una secuencia de eliminación y el personaje quedará fuera de la ronda[cite: 6].
4. [cite_start]**Progresión de Dificultad**: La velocidad de rotación aumenta gradualmente cada 6 vueltas completadas[cite: 10]. [cite_start]Al llegar a la vuelta 10, los fuegos cambian de color (de azul a amarillo) como alerta visual de peligro incrementado[cite: 10].
5. [cite_start]**Victoria**: La partida finaliza cuando solo queda un sobreviviente, quien es declarado ganador[cite: 8]. [cite_start]En caso de que todos sean golpeados simultáneamente, se declara un empate[cite: 8].

## Controles
[cite_start]El juego utiliza un esquema de control compartido en el teclado para facilitar la competencia local[cite: 5]:

| Jugador | Personaje | Selección / Salto |
| :--- | :--- | :--- |
| **P1** | Mario | [cite_start]Tecla `A` [cite: 5, 9] |
| **P2** | Wario | [cite_start]Tecla `V` [cite: 5] |
| **P3** | Peach | [cite_start]Tecla `M` [cite: 5] |
| **P4** | Kong | [cite_start]Tecla `L` [cite: 5] |
| **Sistema** | Iniciar Juego | [cite_start]Tecla `Espacio` [cite: 5, 8] |

## Características Técnicas
* [cite_start]**Sistema de Audio**: Implementado mediante un patrón Singleton que gestiona canales separados para música en bucle y efectos de sonido (SFX) mediante `PlayOneShot`[cite: 1, 2].
* [cite_start]**Físicas de Salto**: Utiliza componentes `Rigidbody` e impulsos verticales, con detección de suelo basada en `Physics.Raycast` para garantizar precisión[cite: 9].
* [cite_start]**Efectos Visuales**: Los obstáculos de fuego presentan un efecto de flotación orgánica mediante la función matemática `Mathf.Sin` y desfases aleatorios[cite: 7].
* [cite_start]**Lógica Global**: Un `GameManager` centralizado coordina la cuenta regresiva inicial, el conteo de jugadores vivos y las condiciones de victoria o empate[cite: 8].

---
*Desarrollado en Unity 3D utilizando C#.*
