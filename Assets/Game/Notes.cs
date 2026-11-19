// Simulated device being used is "Google Pixel 5"

// TODO A2:

// 1. Create basic menu, instruction, gameplay and gameover scenes (No functionality needed except for scene switching)
// 2. Position the assets in the levels to display how they will look like in the finished product.

// • According to your work I will mark for each member. If a member absent, they will get 0.
// • If you not join to this session you will lose that lab of 10% (2.5 points)

// TODO General:
// 1. Implement Safe Zones for UI (So they don't warp too much on different devices)
// 2. Implement a basic pause menu (No functionality needed yet except for scene switching)
// 3. Implement a scene transition for MenuScene PlayButton to GameScene


// Other Notes:

// I don't need to have hover events for buttons since this is designed for a mobile game.
// I want some Animations 


// Gameplay:
// Tap to jump 
// Player auto moves forward (scroller game, uses tilesets?)
// Score increments per second survived, once a certain score is reached, the player will move to the next level (3 levels total)

// L1: 
// - Basic Enemy (Follows behind the player as a collider, if it touches the player, the player dies)
// - Holes in the ground (Player must jump over them, if the player falls in, the player dies)
// - Basic Obstacles (Player must jump over them, if the player touches them, the player slows down significantly. If the player is slowed down enough, the enemy will catch up and kill the player)

// L2:
// - Basic Enemy, Holes & Obstacles (Same as L1)
// - Falling Obstacles (Obstacles now fall from the sky too)
// - Ground will have elevation changes and split platforms to jump across
// - Game speed increases

// L3:
// - Basic Enemy, Holes, Obstacles & Falling Obstacles (Same as L2)
// - Moving Enemies can now spawn (The player will have to jump over them)
// - Game speed increases