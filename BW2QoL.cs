using Il2Cpp;
using Il2CppLuau;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(BW2QoL.BW2QoL), "BW2QoL", "0.0.1", "Hellscaped")]
[assembly: MelonGame("Easy", "Airship")]
namespace BW2QoL;

public class BW2QoL : MelonMod
{
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
        LoggerInstance.Msg($"Script status: {Execute("print('In Lua!')")}");
    }
    private int Execute(string source) 
    {
        AirshipScript script = ScriptableObject.CreateInstance<AirshipScript>();
        LuauCompiler.RuntimeCompile("injected.luau",source,script,false);
        LuauScript.LoadAndExecuteScript(null, LuauContext.Game, LuauScriptCacheMode.NotCached, script, out int status);
        return status;
    }
}