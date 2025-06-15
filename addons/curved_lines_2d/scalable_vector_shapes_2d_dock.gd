@tool
extends TabContainer

signal shape_created(curve : Curve2D, scene_root : Node2D, node_name : String)
signal set_shape_preview(curve : Curve2D)

const IMPORT_TAB_NAME :=  "Import SVG File"
const EDIT_TAB_NAME := "Scalable Vector Shapes"

var warning_dialog : AcceptDialog
var edit_tab : ScalableVectorShapeEditTab
var import_tab : SvgImporterDock

func _enter_tree() -> void:
	warning_dialog = AcceptDialog.new()
	EditorInterface.get_base_control().add_child(warning_dialog)
	import_tab = find_child(IMPORT_TAB_NAME)
	import_tab.warning_dialog = warning_dialog
	edit_tab = find_child(EDIT_TAB_NAME)
	edit_tab.warning_dialog = warning_dialog
	if not edit_tab.shape_created.is_connected(shape_created.emit):
		edit_tab.shape_created.connect(shape_created.emit)
	if not edit_tab.set_shape_preview.is_connected(set_shape_preview.emit):
		edit_tab.set_shape_preview.connect(set_shape_preview.emit)


func _can_drop_data(at_position: Vector2, data: Variant) -> bool:
	if not typeof(data) == TYPE_DICTIONARY and "type" in data and data["type"] == "files":
		return false
	for file : String in data["files"]:
		if file.ends_with(".svg"):
			import_tab.show()
			return true
	return false
