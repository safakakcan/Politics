using System.Collections.Generic;

namespace Politics.Scripts.Models;

public class Character
{
    public uint Id { get; set; }
    public string Name { get; set; }
    
    public Dictionary<uint, Node> Cortex { get; set; } = new();
}