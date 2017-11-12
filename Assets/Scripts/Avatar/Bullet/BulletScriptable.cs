using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu (menuName = "Scriptables/Bullet")]
public class BulletScriptable : ScriptableObject {

	public Sprite bulletImg;
	public AudioSource sound;

	public Bullet bulletPrefab;

}
