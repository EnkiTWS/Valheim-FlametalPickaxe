
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

                // Get the original Black Metal Pickaxe.
                var vanillaPrefab =
                    PrefabManager.Instance.GetPrefab("PickaxeBlackMetal");

                if (vanillaPrefab == null)
                {
                    Logger.LogError(
                        "Vanilla Black Metal Pickaxe prefab not found."
                    );
                    return;
                }

                // Clone the vanilla Black Metal Pickaxe.
                var pickaxe = new CustomItem(
                    ItemPrefabName,
                    "PickaxeBlackMetal",
                    config
                );

                var vanillaDrop =
                    vanillaPrefab.GetComponent<ItemDrop>();

                // Verify both items have valid data.
                if (vanillaDrop == null ||
                    pickaxe.ItemDrop == null ||
                    vanillaDrop.m_itemData?.m_shared == null ||
                    pickaxe.ItemDrop.m_itemData?.m_shared == null)
                {
                    Logger.LogError(
                        "Pickaxe validation failed: missing item data."
                    );
                    return;
                }

                var vanillaData = vanillaDrop.m_itemData.m_shared;
                var customData = pickaxe.ItemDrop.m_itemData.m_shared;

                // Prevent modifying the original item's SharedData.
                if (System.Object.ReferenceEquals(vanillaData, customData))
                {
                    Logger.LogError(
                        "Unsafe shared item data detected. " +
                        "Flametal Pickaxe registration aborted."
                    );
                    return;
                }

                // Record the original properties.
                int originalToolTier = vanillaData.m_toolTier;
                int originalMaxQuality = vanillaData.m_maxQuality;

                // Modify ONLY our custom pickaxe.
                customData.m_toolTier = 6;
                customData.m_maxQuality = 1;

                // Make sure the original pickaxe is unchanged.
                if (vanillaData.m_toolTier != originalToolTier ||
                    vanillaData.m_maxQuality != originalMaxQuality)
                {
                    Logger.LogError(
                        "Vanilla pickaxe data changed unexpectedly!"
                    );
                    return;
                }

                Logger.LogInfo(
                    "Vanilla Black Metal tool tier: " +
                    vanillaData.m_toolTier
                );

                Logger.LogInfo(
                    "Flametal Pickaxe tool tier: " +
                    customData.m_toolTier
                );

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
