using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Occult.UnityHelper.CustomScripts{
	public static class CustomScriptTemplate {
		// Add a new Class Type for each new class definition
		public enum ClassTypes {
			Basic_Class
		}
		// This is an example of a class definition. There are better ways to do this (Like loading template files from the Editor Default Resources), but I wanted to fit this in a single, easy to understand Gist.
		private static string basicClassDefinition = 
			"using UnityEngine;" + System.Environment.NewLine +
			"using System.Collections;" + System.Environment.NewLine +
			System.Environment.NewLine +
			"public class #NEW_SCRIPT_NAME# {" + System.Environment.NewLine + // Make sure to set the new class name to #NEW_SCRIPT_NAME#
			System.Environment.NewLine +
			"}";

		[MenuItem("Assets/Create Script Generation", false, 0)]
		public static void CreateCustomScript(MenuCommand cmd) {
			CreateScriptWindow window = new CreateScriptWindow(delegate(string className, ClassTypes classType){
				string basePath = "";

				if(Selection.activeObject !=null && Directory.Exists(Selection.activeObject.name)){
					basePath = Application.dataPath.Replace("Assets", "") + Selection.activeObject.name+"/"+className+".cs";
				} else if(Selection.activeObject !=null){
					basePath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(Selection.activeObject))+"/"+className+".cs";
				} else {
					basePath = "Assets/"+className+".cs";
				}

				if(File.Exists(basePath) == false){
					string writeFile = "";
					switch(classType){
					case ClassTypes.Basic_Class:
						writeFile = basicClassDefinition;
						break;
					}
					writeFile = writeFile.Replace("#NEW_SCRIPT_NAME#",className);
					using (StreamWriter outfile = new StreamWriter(basePath)) {
						outfile.WriteLine(writeFile);
					}//File written
				}
				AssetDatabase.Refresh();
				Object obj = AssetDatabase.LoadAssetAtPath(basePath, typeof(Object));
				Selection.activeObject = obj;
				EditorUtility.FocusProjectWindow ();
			});
			window.ShowUtility();
		}
	}
	// This class is just responsible for drawing the window.
	public class CreateScriptWindow : EditorWindow {
		public string editorWindowText = "New Script Name: ";
		public string scriptName = "New_Script";
		public CustomScriptTemplate.ClassTypes classType = CustomScriptTemplate.ClassTypes.Basic_Class;
		private OnComplete onCompleteAction;
		public delegate void OnComplete(string _value, CustomScriptTemplate.ClassTypes _class);

		public CreateScriptWindow(OnComplete onComplete){
			onCompleteAction = onComplete;
		}

		void OnGUI() {
			EditorGUILayout.Space ();
			scriptName = EditorGUILayout.TextField(editorWindowText, scriptName);
			EditorGUILayout.Space ();
			classType = (CustomScriptTemplate.ClassTypes)EditorGUILayout.EnumPopup ("Script Type: ", classType);
			EditorGUILayout.Space ();
			EditorGUILayout.Space ();
			if (GUILayout.Button ("Okay")) {
				Close();
				onCompleteAction.Invoke (scriptName, classType);
			}
			EditorGUILayout.Space ();
			if (GUILayout.Button("Abort"))
				Close();
		}
	}
}