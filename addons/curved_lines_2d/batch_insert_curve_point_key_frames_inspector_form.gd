@tool
extends KeyframeButtonCapableInspectorFormBase

var batch_insert_button : Button
var scalable_vector_shape_2d : ScalableVectorShape2D

func _enter_tree() -> void:
	batch_insert_button = find_child("BatchInsertButton")
	_initialize_keyframe_capabilities()


func _on_key_frame_capabilities_changed() -> void:
	if _is_key_frame_capable():
		batch_insert_button.disabled = false
	else:
		batch_insert_button.disabled = true


func _on_batch_insert_button_pressed() -> void:
	var animation_name := animation_under_edit_button.get_item_text(animation_under_edit_button.get_selected_id())
	var animation_player := _find_animation_player(animation_name)
	var animation := _guarded_get_animation(animation_player)
	var path_to_node := _guarded_get_path_to_node(animation_player, scalable_vector_shape_2d)
	var track_position := _guarded_get_track_position()
	if not animation:
		return
	if path_to_node.is_empty():
		return
	var undo_redo := EditorInterface.get_editor_undo_redo()
	undo_redo.create_action("Batch insert curve keyframes for %s on animation %s" % [str(scalable_vector_shape_2d), str(animation)])
	for p_idx in range(scalable_vector_shape_2d.curve.point_count):
		_add_key_frame(undo_redo, animation, NodePath("%s:curve:point_%d/position" % [path_to_node, p_idx]),
				track_position, scalable_vector_shape_2d.curve.get_point_position(p_idx))
		if p_idx > 0:
			_add_key_frame(undo_redo, animation, NodePath("%s:curve:point_%d/in" % [path_to_node, p_idx]),
					track_position, scalable_vector_shape_2d.curve.get_point_in(p_idx))
		if p_idx < scalable_vector_shape_2d.curve.point_count - 1:
			_add_key_frame(undo_redo, animation, NodePath("%s:curve:point_%d/out" % [path_to_node, p_idx]),
					track_position, scalable_vector_shape_2d.curve.get_point_out(p_idx))
	undo_redo.commit_action()
