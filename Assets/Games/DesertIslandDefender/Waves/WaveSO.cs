using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class WaveSO : ScriptableObject
{
    public List<wavePart> waveElements;
}

[System.Serializable]
public class wavePart {
    public GameObject enemy;
    public int amount, delay;
}