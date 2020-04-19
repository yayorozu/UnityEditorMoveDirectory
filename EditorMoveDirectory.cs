using UnityEditor;
using UnityEngine;
 
public static class EditorMoveDirectory
{
	[MenuItem("Assets/Move Directory")]
	private static void MoveAssets()
	{
		var guids = Selection.assetGUIDs;
		if (guids.Length <= 0)
			return;
 
		var path = EditorUtility.OpenFolderPanel("Select Move Directory", "Assets", "");
		if (string.IsNullOrEmpty(path))
			return;
 
		var inProjectPath = path.Replace(Application.dataPath, "Assets");
		foreach (var guid in guids)
		{
			var assetPath = AssetDatabase.GUIDToAssetPath(guid);
			var fileName = System.IO.Path.GetFileName(assetPath);
			AssetDatabase.MoveAsset(assetPath, System.IO.Path.Combine(inProjectPath, fileName));
		}
	}
}