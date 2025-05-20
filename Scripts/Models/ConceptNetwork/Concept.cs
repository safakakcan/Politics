using System.Collections.Generic;

namespace Politics.Scripts.Models;

public class Concept : Node
{
    public override NodeType Type { get; set; } = NodeType.Concept;

    public Concept(uint id, string name)
    {
        Id = id;
        Name = name;
    }
}