using System;
using System.Collections.Generic;
using System.Linq;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Hooking;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.GeneratedSheets2;
using XIVSlothCombo.Combos.PvE;
using XIVSlothCombo.CustomComboNS;
using XIVSlothCombo.Services;
using Action = Lumina.Excel.GeneratedSheets.Action;


namespace XIVSlothCombo.Utils;

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
        //check if in battle
        bool inCombat = Conditions.IsInCombat;
        
        if (CustomCombo.NewActionID == actionId && actionType == ActionType.Action)
        {
            return true;
        }
        
        return false;
    }
    
    
}