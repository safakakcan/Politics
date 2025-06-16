using Godot;
using System;
using Politics.Scripts.Models;

public partial class Unit : Sprite2D
{
	public uint UnitId;
	public int UnitType;
	public RangeValue Health;
	public RangeValue Morale;
	public RangeValue Energy;
	public RangeValue Ammo;
	public RangeValue Supply;
	public float Experience;
	public float MovementSpeed;

	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		
	}
}
