using UnityEngine;
using UnityEditor;
/// <summary>
/// Int attribute bar drawer.
/// </summary>
[CustomPropertyDrawer(typeof(IntAttributeBar))]
public class IntAttributeBarDrawer : PropertyDrawer {
	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="property">Property.</param>
	/// <param name="label">Label.</param>
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label){
		EditorGUI.BeginProperty (position, label, property);
		//Prefix Label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
		position.x -= 75;
		//Properties
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		EditorGUI.LabelField (new Rect (position.x, position.y, 52, position.height), "Current:");
		EditorGUI.PropertyField(new Rect(position.x+52, position.y, 40, position.height), property.FindPropertyRelative("current"), GUIContent.none);
		EditorGUI.LabelField (new Rect (position.x+92, position.y, 30, position.height), "Max:");
		EditorGUI.PropertyField(new Rect(position.x+122, position.y, 40, position.height), property.FindPropertyRelative("max"), GUIContent.none);
		//Draw Bar
		int current = property.FindPropertyRelative ("current").intValue;
		int maximum = property.FindPropertyRelative ("max").intValue;
		float percent = (Mathf.Clamp(current*1f,0, maximum) / maximum*1f);
		if (maximum > 0) {
			EditorGUI.DrawRect (new Rect (position.x + 166, position.y, 150, position.height), Color.red);
			EditorGUI.DrawRect (new Rect (position.x + 166, position.y, 150 * percent, position.height), Color.green);
			EditorGUI.LabelField (new Rect (position.x + 166, position.y, 150, position.height), "" + current + "/" + maximum);
		} else {
			EditorGUI.LabelField (new Rect (position.x + 166, position.y, 150, position.height), "Max can't be - or 0.");
		}
		//Wrap up
		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty ();
	}
}