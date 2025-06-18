using System.Collections.Generic;

namespace Politics.Scripts;

public class Army
{
    public uint ArmyId;
    public uint FactionId;
    public uint CommanderId;
    public HashSet<uint> UnitIds;
}