using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// This class will be used to load resources into subclasses.  It allows the object pool to more easily initialize objects generically without needing prefabs for each subclassed object.
/// </summary>
public class ResourceController : MonoBehaviour, IController
{
    public AnimationClip[] animations;
	public AudioClip[] soundEffects; //just putting all sound effects in one array for now

	// Use this for initialization
	void Start () 
	{
        animations = Resources.LoadAll<AnimationClip>("Animations");
		soundEffects = Resources.LoadAll<AudioClip>("Audio/SoundEffects");
		//DebugAllSprites();
	}

    #region Visuals

    public AnimationClip GetAnimation(string name)
    {
        for (int i = 0; i < animations.Length; i++)
        {
            if (animations[i].name == name)
            {
                return animations[i];
            }
        }

        return null;
    }

    public bool TryGetAnimation(string name, out AnimationClip value)
	{
        value = GetAnimation(name);
        return (value != null);
	}

	#endregion Visuals

	#region Audio
	
	//returns the entire array of sound effects
	public AudioClip[] GetAllSoundEffects()
	{
		return soundEffects;
	}

	public bool TryGetSoundEffect(string name, out AudioClip value)
	{
		bool found = false;
		value = null;

		for (int i = 0; i < soundEffects.Length; i++)
		{
			if (soundEffects[i].name == name)
			{
				value = soundEffects[i];
				found = true;
				break;
			}
		}

		//didn't find the sound effect
		return found;
	}

	#endregion Audio


	#region IController

	public void Cleanup()
	{

	}

	#endregion IController
	
}
