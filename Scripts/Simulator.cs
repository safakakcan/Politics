using System;
using System.Collections.Generic;
using Politics.Scripts.Models;
using Node = Godot.Node;

public partial class Simulator : Node
{
    public Dictionary<uint, Character> Characters = new Dictionary<uint, Character>();
    
    public void PropagateInCortex(uint characterId, uint originNodeId)
    {
        if (Characters.TryGetValue(characterId, out var character))
        {
            var queue = new Queue<uint>();
            var visited = new HashSet<uint>();
            queue.Enqueue(originNodeId);
            visited.Add(originNodeId);
            
            while (queue.Count > 0)
            {
                if (queue.TryDequeue(out uint nodeId))
                {
                    if (character.Cortex.TryGetValue(nodeId, out var node))
                    {
                        foreach (var kvp in node.Synapses)
                        {
                            if (!visited.Contains(kvp.Key))
                            {
                                if (!queue.Contains(kvp.Key)) queue.Enqueue(kvp.Key);
                                if (character.Cortex.TryGetValue(kvp.Key, out var linkedNode))
                                {
                                    if (node.Activation > node.Threshold) linkedNode.Activation += node.Activation * kvp.Value;
                                }
                            }
                        }
                        
                        foreach (var kvp in node.Synapses) visited.Add(kvp.Key);
                    }
                }
            }
        }
    }
}
