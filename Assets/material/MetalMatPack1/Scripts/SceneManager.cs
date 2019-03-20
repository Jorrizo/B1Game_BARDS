using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	
	public Material[] materialsBronze;
	public Material[] materialsChrome;
	public Material[] materialsGold;
	
	public enum MetalType
	{
		Bronze,
		Chrome,
		Gold
	}
	
	public MetalType type = MetalType.Chrome;
	int currentMat = 0;
	
	void OnGUI ()
	{
		
		if (GUI.Button (new Rect (120, 20, 80, 20), "Bronze")) {
			type = MetalType.Bronze;
			SetMaterials (materialsBronze [currentMat]);
		}
		
		if (GUI.Button (new Rect (220, 20, 80, 20), "Chrome")) {
			type = MetalType.Chrome;
			SetMaterials (materialsChrome [currentMat]);
		}
		
		if (GUI.Button (new Rect (320, 20, 80, 20), "Gold")) {
			type = MetalType.Gold;
			SetMaterials (materialsGold [currentMat]);
		}
		
		
		Material[] mats;
		switch (type) {
		case MetalType.Bronze:
			mats = materialsBronze;
			break;
		case	MetalType.Chrome:
			mats = materialsChrome;
			break;
		case	MetalType.Gold:
			mats = materialsGold;
			break;
			
		default:
			mats = materialsChrome;
			break;
		}
		
		int i = 0;
		foreach (Material item in mats) {
			if (GUI.Button (new Rect (20, 60 + 30 * i, 80, 20), item.name)) {
				SetMaterials (item);
				currentMat = i;
			}
			i++;
		}
		
	}
	
	void SetMaterials (Material material)
	{
		Renderer[] rens = GetComponentsInChildren<MeshRenderer> ();
		foreach (Renderer item in rens) {
			item.sharedMaterial = material;
		}
	}
}
