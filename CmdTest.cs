using System;

namespace PlentifulOres;

public class CmdTest : ModCommand
{
    public override string Command => "test";
    public override CommandType Type => CommandType.World;

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        // Test
    }
}
