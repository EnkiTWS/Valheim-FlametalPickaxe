
using System.IO;
using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace FlametalPickaxe
{
    [BepInPlugin(
        "com.flametalpickaxe.mod",
        "Flametal Pickaxe",
        "1.0.0")]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class FlametalPickaxePlugin : BaseUnityPlugin
    {
        private const string ItemPrefabName = "FlametalPickaxe";

        private void Awake()
        {
            Logger.LogInfo("Flametal Pickaxe initializing.");

            PrefabManager.OnVanillaPrefabsAvailable += RegisterPickaxe;
        }

        private void RegisterPickaxe()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= RegisterPickaxe;

            try
            {
                // Load the icon relative to the plugin DLL.
                string modFolder = Path.GetDirectoryName(Info.Location);
                string iconPath = Path.Combine(
                    modFolder,
                    "flametalpickaxe.png"
                );

                Sprite icon = AssetUtils.LoadSpriteFromFile(iconPath);

                if (icon == null)
                {
                    Logger.LogWarning(
                        "Custom icon could not be loaded: " + iconPath
                    );
                }
                else
                {
                    Logger.LogInfo("Custom icon loaded successfully!");
                }

                // Configure the new item.
                var config = new ItemConfig
                {
                    Name = "Flametal Pickaxe",
                    Description = "A powerful Flametal pickaxe capable of breaking exceptionally tough stone.",
                    CraftingStation = "blackforge",
                    Amount = 1,
                    Icon = icon
                };

                // Crafting requirements.
                config.AddRequirement("FlametalNew", 25);
                config.AddRequirement("Blackwood", 10);

                // Clone the vanilla Black Metal Pickaxe.
                var pickaxe = new CustomItem(
                    ItemPrefabName,
                    "PickaxeBlackMetal",
                    config
                );

                if (pickaxe.ItemDrop == null)
                {
                    Logger.LogError("Cloned pickaxe has no ItemDrop!");
                    return;
                }

                // Enable tier-6 mining.
                pickaxe.ItemDrop.m_itemData.m_shared.m_toolTier = 6;

                // Disable upgrades.
                pickaxe.ItemDrop.m_itemData.m_shared.m_maxQuality = 1;

                // Assign the custom inventory icon.
                if (icon != null)
                {
                    pickaxe.ItemDrop.m_itemData.m_shared.m_icons =
                        new Sprite[] { icon };

                    Logger.LogInfo("Flametal Pickaxe sprite assigned.");
                }

                // Register the item with Jötunn.
                bool success = ItemManager.Instance.AddItem(pickaxe);

                if (success)
                {
                    Logger.LogInfo(
                        "Flametal Pickaxe registered successfully!"
                    );
                }
                else
                {
                    Logger.LogError(
                        "Failed to register Flametal Pickaxe."
                    );
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogError(
                    "Flametal Pickaxe error: " + ex
                );
            }
        }
    }
}
