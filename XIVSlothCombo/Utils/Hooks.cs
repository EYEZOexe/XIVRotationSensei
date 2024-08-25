using System;
using System.Collections.Generic;
using System.Linq;
using Dalamud.Hooking;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;
using XIVSlothCombo.Services;
using Action = Lumina.Excel.GeneratedSheets.Action;


namespace XIVSlothCombo.Utils;

public sealed unsafe class Hooks : IDisposable
{
    public readonly Hook<ActionManager.Delegates.IsActionHighlighted> IsActionHighlightedHook = null!;
    
    private Dictionary<uint, Action> CachedActions;
    
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
        bool result = IsActionHighlightedHook.Original(manager, actionType, actionId);
        // if (result) return result;
        // if (actionType != ActionType.Action) return result;
        //if (CachedActions == null) CacheActions();
        //var action = CachedActions[actionId];
        //if (actionId == 16143) return true;
        
        return result;
    }
    
    
}