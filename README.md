# Reusable-Unity-Scripts
CURRENTLY INCLUDES: 
--> JumpEffect.cs: This script override's unity's default RB:Gravity calculations and highly smoothens a player's jump effect by applying realistic -Y-axis acceleration. 
  Recommended use on RIGIDBODY component.
  
--> CameraMovement.cs: Perfect camera script for any 3D game. Prevents camera from going below terrain/ground by locking at a certain angle relative to the player.
    Another feature of this script is the automated, slow and smooth redirection of the camera back to it's former position behind the player. Can be adjusted/turned off.
    More about the script in its comments. 
    
--> PlayerController.cs: A basic script that any player-controlled character should have attached if their main physics component is a rigidbody.
--> PlayerCC.cs: A modified version of the PlayerController.cs that works with CHARACTER CONTROLLER component.

  NOTE: Although the CHARACTER CONTROLLER component has its pros, it is quite often GLITCHY and not used a lot compared to RIGIDBODY component. 
  The PlayerCC.cs DOES NOT GUARANTEE bug fixes but proves to be in concord with Character Controller component. If you find that it quite often glitches, I recommend
  switching to RIGIDBODY Component. 
