using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public AudioSource myFx;
	public AudioClip click;

public void ClickSound() //событие нажатия кнопки
	{
		myFx.PlayOneShot(click);
	}

}
