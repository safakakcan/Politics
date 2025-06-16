using System;
using System.Collections.Generic;
using Politics.Scripts.Models;
using Node = Godot.Node;

public partial class Simulator : Node
{
	public Dictionary<uint, Character> Characters = new Dictionary<uint, Character>();
	
	public void PropagateInCortex(uint characterId, uint originNodeId, float intensity = 1.0f, float decay = 0.1f)
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
									linkedNode.Activation += node.Activation * kvp.Value * intensity;
									node.Synapses[kvp.Key] *= node.Activation + linkedNode.Activation > 1.0f ? 1 : 1 - decay;
								}
							}
						}

						intensity *= 1 - decay;
						
						foreach (var kvp in node.Synapses) visited.Add(kvp.Key);
					}
				}
			}
		}
	}
}
