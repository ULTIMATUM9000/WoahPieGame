using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
	public Sound[] sounds;
	protected override void Awake()
	{
		base.Awake();
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.playOnAwake = s.playOnAwake;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play(string Part01name, string Part02name)
	{
		Sound part01 = Array.Find(sounds, sound => sound.name == Part01name);
		Sound part02 = Array.Find(sounds, sound => sound.name == Part02name);

		StartCoroutine(PlayBGM(part01,part02));
	}

	IEnumerator PlayBGM(Sound part01, Sound part02)
	{
		part01.source.Play();
		yield return new WaitForSecondsRealtime(part01.clip.length);
		part02.source.Play();
	}

	public void Stop(string Part01Name, string Part02Name)
	{
		Sound part01 = Array.Find(sounds, sound => sound.name == Part01Name);
		Sound part02 = Array.Find(sounds, sound => sound.name == Part02Name);

		if (part01.source.enabled)
		{
			part01.source.Stop();
		}

		if (part02.source.enabled)
		{
			part02.source.Stop();
		}
	}
}

