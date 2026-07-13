using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLocationSaver", menuName = "Scriptable Objects/PlayerLocationSaver")]
public class PlayerLocationSaverObject : ScriptableObject
{
    public bool doSetLocation = false;
    public Vector3 position;
    public Quaternion rotation;
}
