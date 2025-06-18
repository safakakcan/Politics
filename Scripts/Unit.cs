using Godot;
using System;
using Politics.Scripts.Models;

public partial class Unit : Sprite2D
{
	public uint UnitId;
	public UnitType UnitType;
	public RangeValue Health;
	public RangeValue Morale;
	public RangeValue Energy;
	public RangeValue Ammo;
	public RangeValue Supply;
	public float Experience;
	public float MovementSpeed;
	public float Resistance;
	public float Stealth;
	public float Suppression;
	public float FirePower;
	public float Accuracy;
	public VisionArea VisionArea;
	
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		
	}
}
