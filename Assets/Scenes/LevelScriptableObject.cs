using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "LevelData")]
public class LevelScriptableObject : ScriptableObject
{
    [SerializeField]
    public SceneAsset scene;
    [Range(0,1)]
    public float difficulty;
}
