# Kitchen Chaos Recreation

A Unity recreation project developed while following the Kitchen Chaos tutorial. The project currently includes player input, movement, rotation, animation, and collision setup.

## Milestone 1

**Tutorial progress:** Episode 13, approximately 2.5 hours  
**Completion date:** 27 September 2026

### Work completed

- Configured Unity's new Input System with a Player Action Map and a 2D Vector Composite for WASD movement.
- Implemented normalized player movement and smooth rotation using `Vector3.Slerp`.
- Connected the player's walking state to separate idle and walking animations.
- Added a Collider and Rigidbody constraints to prevent the player from tipping over.
- Moved player calculations into `FixedUpdate` to follow the fixed physics timing.

### Evidence

- Tutorial progress screenshot: **Add screenshot here**
- [Game View recording](https://youtu.be/tsoGaSb0wOM)
- [GitHub commit](https://github.com/ppxjing/KitchenChaos2026/commit/0a91cb86240767284a61b725003c0485061a11eb)

### What I learned

`Vector3.Slerp` creates smooth player rotation, while a zero-vector check keeps the player's last facing direction when movement stops. Private fields protect data from direct access by other classes, and `SerializeField` allows those fields to remain editable in the Unity Inspector.

Separating player movement from visual animation prevents both systems from changing the same position and interfering with each other. Unity's new Input System also separates control bindings from gameplay logic. A 2D Vector Composite combines four directional keys into one movement value, while Action Maps organize related controls. `FixedUpdate` follows the fixed timing used by Rigidbody physics calculations, keeping movement and physics calculations on the same update cycle.
