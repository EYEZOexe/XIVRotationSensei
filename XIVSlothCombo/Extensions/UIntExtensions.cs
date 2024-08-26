using XIVRotationSensei.CustomComboNS.Functions;
using XIVRotationSensei.Data;

namespace XIVRotationSensei.Extensions
{
    internal static class UIntExtensions
    {
        internal static bool LevelChecked(this uint value) => CustomComboFunctions.LevelChecked(value);

        internal static bool TraitLevelChecked(this uint value) => CustomComboFunctions.TraitLevelChecked(value);

        internal static string ActionName(this uint value) => ActionWatching.GetActionName(value);
    }

    internal static class UShortExtensions
    {
        internal static string StatusName(this ushort value) => ActionWatching.GetStatusName(value);
    }
}
