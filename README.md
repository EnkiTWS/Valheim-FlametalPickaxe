# Flametal Pickaxe

A lightweight Valheim mod that adds a craftable **Flametal Pickaxe**, capable of mining extremely tough deposits, including petrified Gammeltrolls in the Deep North.

Built using BepInEx and Jötunn, the Flametal Pickaxe is based on the Black Metal Pickaxe, with increased mining capability and a custom inventory icon.

## ⚠️ Known Issue: Multiplayer Storage Compatibility

**An intermittent issue has been observed when playing on dedicated servers with Flametal Pickaxe enabled.**
Weapons and tools stored in **non-vanilla storage containers**, including containers added by other mods such as **Landscaper**, may temporarily appear to disappear from their inventory slots.

**IMPORTANT: Do not place anything into the apparently empty slots!**

Although the missing items generally reappear after restarting Valheim, placing new items into those slots can cause the original items to be **permanently deleted**.
- The issue has only been observed in multiplayer environments.
- It appears to affect weapons and tools stored in non-vanilla containers, including some modded furniture and storage.
- Restarting Valheim has restored the apparently missing items in our testing, provided the affected inventory slots were left untouched.
- Overwriting an affected slot can result in permanent item loss.
- The issue has not been reliably reproduced in controlled testing, so its underlying cause remains unknown.
- No equivalent issue has been observed during single-player testing.

### Multiplayer Recommendations

- **Jötunn is recommended on dedicated servers** when using Flametal Pickaxe, even if it is not already part of the server's mod setup. This is a precaution, not a confirmed fix.
- Back up your world and character data before installing or updating mods.
- If stored items appear to be missing, **do not move new items into the affected slots**. Close Valheim completely, restart, and verify the contents.
- Consider avoiding non-vanilla storage containers for valuable weapons and tools until the issue is understood.

**Status:** Under investigation. The problem is intermittent and has not been consistently reproducible.

## Features
- Adds a new craftable **Flametal Pickaxe**.
- Provides **tier-6 mining capability** for exceptionally tough deposits.
- Capable of mining petrified Gammeltroll remains in the Deep North.
- Uses the Black Metal Pickaxe as its visual base.
- Includes a custom inventory icon.
- Crafted at the **Black Forge**.
- Maximum quality level of 1, with no upgrades.

## Crafting Recipe

**Crafting Station:** Black Forge

| Material | Amount |
|---|---:|
| Flametal | 25 |
| Ashwood | 10 |

## Installation

1. Install BepInExPack for Valheim.
2. Install Jötunn.
3. Install Flametal Pickaxe through r2modman, Thunderstore Mod Manager, or manually.
4. Launch Valheim.
For manual installation, place `FlametalPickaxe.dll` and `flametalpickaxe.png` together in a folder inside `BepInEx/plugins`.

### Dedicated Servers

Server-side Jötunn installation is recommended as a precaution while multiplayer compatibility is investigated.
The mod has successfully connected to dedicated servers both with and without Jötunn installed server-side. However, this does not guarantee compatibility with every server or other installed mods.
Players without the custom item installed may not be able to use or correctly display the Flametal Pickaxe.
