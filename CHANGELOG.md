## Changelog

### v1.0.1: Stability and Diagnostics
This release introduces defensive checks and additional logging following reports of intermittent multiplayer inventory issues.

**Changes:**
- Added validation of the original Black Metal Pickaxe prefab and item data.
- Added checks to ensure the Flametal Pickaxe does not share the original item's `SharedData` object.
- Added safeguards to abort registration if shared item data is detected.
- Added diagnostic logging of vanilla and Flametal Pickaxe mining tiers.
- Added checks to detect unexpected modifications to vanilla Black Metal Pickaxe properties.
- Updated multiplayer guidance and documented the known non-vanilla storage issue.

**Note:** These safeguards help detect certain unsafe item-data conditions. They do not constitute a confirmed fix for the intermittent multiplayer storage issue.

### v1.0.0: Initial Release
- Added the Flametal Pickaxe.
- Added tier-6 mining capability.
- Added Black Forge crafting recipe.
- Added custom inventory icon.
- Added support for mining petrified Gammeltroll remains.

## Compatibility

**Required dependencies:**
- BepInExPack for Valheim
- Jötunn
**Optional compatibility:**
- Veinmine can be used alongside Flametal Pickaxe, but is not required.
Multiplayer behavior may vary depending on server configuration and installed mods.

Created by **EnkiPlaysGames**.

Built with Jötunn, BepInEx, and a healthy amount of stubborn Viking experimentation.
