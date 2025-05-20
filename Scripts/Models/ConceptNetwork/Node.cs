using Godot.Collections;

namespace Politics.Scripts.Models;

public abstract class Node
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public abstract NodeType Type { get; set; }
    public float Activation { get; set; }
    public float Threshold { get; set; }
    public Dictionary<uint, float> Synapses { get; set; } = new Dictionary<uint, float>();
}