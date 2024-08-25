using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using XIVSlothCombo.Core;
using XIVSlothCombo.Data;


namespace XIVSlothCombo.Services
{
    /// <summary> Dalamud and plugin services. </summary>
    internal class Service
    {
        /// <summary> Gets or sets the plugin address resolver. </summary>
        internal static PluginAddressResolver Address { get; set; } = null!;

        /// <summary> Gets or sets the plugin caching mechanism. </summary>
        internal static CustomComboCache ComboCache { get; set; } = null!;

        /// <summary> Gets or sets the plugin configuration. </summary>
        internal static PluginConfiguration Configuration { get; set; } = null!;

        /// <summary> Gets or sets the plugin icon replacer. </summary>
        internal static IconReplacer IconReplacer { get; set; } = null!;

        [PluginService] public static IGameInteropProvider GameInteropProvider { get; private set; } = null!;
        [PluginService] public static IDataManager DataManager { get; private set; } = null!;
        
        public static XIVSlothCombo Plugin { get; private set; }
        
        internal static void Initialize(XIVSlothCombo plugin, IDalamudPluginInterface iface)
        {
            Plugin = plugin;
            iface.Create<Service>();
        }
    }
}
