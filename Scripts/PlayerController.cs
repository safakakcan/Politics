using Godot;
using System;
using System.Diagnostics;

public partial class PlayerController : Camera2D
{
	[Export] public uint FactionId;
	
	private Vector2 dragStartPosition;
	private bool dragging = false;

	public override void _Process(double delta)
	{
		if (dragging)
		{
			if (Input.IsMouseButtonPressed(MouseButton.Left))
			{
				var mousePosition = GetGlobalMousePosition();
				Vector2 dragDelta = dragStartPosition - mousePosition;
				Translate(dragDelta);
				GlobalPosition += dragDelta;
				dragStartPosition = mousePosition;
			}
			else
			{
				dragging = false;
			}
		}
		else
		{
			if (Input.IsMouseButtonPressed(MouseButton.Left))
			{
				dragStartPosition = GetGlobalMousePosition();
				dragging = true;
			}
		}
	}
}
