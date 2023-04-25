# Matthews-journey
game for H.W 5. based on mario game
[https://elonnyosef.itch.io/matthews-journey](https://elonnyosef.itch.io/matthews-journey)

In our 2D game, we created a hero character, Mario, and an enemy that moves side to side. We implemented the hero's movement, including walking and jumping, using a hero controller script. We also created an enemy patrol script to manage the enemy's movement between two points, walking back and forth.

To detect and handle collisions between the hero and the enemy, we set up triggers and physics layers, ensuring that the physics engine wouldn't interfere with the enemy's movement. We used the OnTriggerEnter2D method in our hero controller script to handle the interactions between the hero and the enemy. When the hero touches the enemy on the x-axis, the hero returns to the starting position. When the hero falls on the enemy, the enemy disappears if a strong enough impulse force is applied.

Additionally, we introduced a pole-sliding mechanic for the hero to safely descend from high platforms. We achieved this by modifying the hero controller script to detect when the hero is near the pole and slide down at a controlled speed. We also added a condition to stop the slide when the hero reaches the bottom of the pole.

Throughout the development process, we have made various adjustments and improvements to ensure a smooth gaming experience and the correct implementation of the desired mechanics.
