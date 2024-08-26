using System;
using System.Collections.Generic;
using System.Linq;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Hooking;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.GeneratedSheets2;
using XIVRotationSensei.Combos.PvE;
using XIVRotationSensei.CustomComboNS;
using XIVRotationSensei.Services;
using Action = Lumina.Excel.GeneratedSheets.Action;


namespace XIVRotationSensei.Utils;

public sealed unsafe class Hooks : IDisposable
{
    public readonly Hook<ActionManager.Delegates.IsActionHighlighted> IsActionHighlightedHook = null!;
    
    public Hooks()
    {
        IsActionHighlightedHook = Service.GameInteropProvider.HookFromAddress<ActionManager.Delegates.IsActionHighlighted>(ActionManager.MemberFunctionPointers.IsActionHighlighted, HandleIsActionHighlighted);
        
        //CacheActions();
        
        IsActionHighlightedHook.Enable();
    }
    
    
    public void Dispose()
    {
        IsActionHighlightedHook.Dispose();
    }
    
    private bool HandleIsActionHighlighted(ActionManager* manager, ActionType actionType, uint actionId)
    {
        if (!Service.Configuration.TeachingMode) return false;
        //bool inCombat = Conditions.IsInCombat;
        
        if (CustomCombo.NewActionID == actionId && actionType == ActionType.Action)
        {
            return true;
        }
        
        return false;
    }
    
    
}