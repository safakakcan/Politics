using Godot;
using System;

public partial class PlayerController : Camera2D
{
	[Export] public uint FactionId;
	
	private Vector2 dragStartPos;
	private Vector2 cameraStartPos;
	private bool dragging = false;

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touchEvent)
		{
			if (touchEvent.Pressed && !IsMouseOverUI())
			{
				dragging = true;
				dragStartPos = touchEvent.Position;
				cameraStartPos = GlobalPosition;
			}
			else if (!touchEvent.Pressed)
			{
				dragging = false;
			}
		}
		
		else if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left && !mouseEvent.IsEcho() && !IsMouseOverUI())
			{
				if (mouseEvent.Pressed)
				{
					dragging = true;
					dragStartPos = mouseEvent.Position;
					cameraStartPos = GlobalPosition;
				}
				else
				{
					dragging = false;
				}
			}
		}
		
		else if (@event is InputEventScreenDrag screenDragEvent)
		{
			if (!IsMouseOverUI())
			{
				dragging = true;
				Vector2 delta = dragStartPos - screenDragEvent.Position;
				GlobalPosition = cameraStartPos + delta;
			}
		}
	}

	public override void _Process(double delta)
	{
		if (dragging && Input.IsMouseButtonPressed(MouseButton.Left))
		{
			Vector2 dragDelta = dragStartPos - GetGlobalMousePosition();
			GlobalPosition = cameraStartPos + dragDelta;
		}
		GD.Print(GlobalPosition);
	}

	private bool IsMouseOverUI()
	{
		return GetViewport().GuiGetFocusOwner() != null;
	}
}
