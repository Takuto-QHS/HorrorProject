using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptableObject", menuName = "Scriptable Objects/SoundScriptableObject")]
public class SoundScriptableObject : ScriptableObject
{
    [Header("BGM")]
    public AudioClip clipTitle;
    public AudioClip clip0F;
    public AudioClip clip1F;
    public AudioClip clip2F;
    public AudioClip clip3F;
    public AudioClip clipB2F;

}
