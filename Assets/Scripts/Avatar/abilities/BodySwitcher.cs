using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySwitcher : PlayerAbility {

	public GameObject human;
	public GameObject ball;
	private PlayerHealth _ballHealth;
	private PlayerHealth _humanHealth;
	private bool _isHumanStatus;
	

    public override void Action()
    {
        if (Input.GetButtonDown(axis))
		{
			_isHumanStatus = !_isHumanStatus;
			ActiveHumanStatus(_isHumanStatus);
			SyncBody();
		}
    }

    // Use this for initialization
    protected override void Start () {
		base.Start();
		_humanHealth = human.GetComponent<PlayerHealth>();
		_ballHealth = ball.GetComponent<PlayerHealth>();
		_isHumanStatus = true;
		ActiveHumanStatus(_isHumanStatus);
	}
	
	void ActiveHumanStatus(bool active)
	{
		ball.SetActive(!active);
		human.SetActive(active);
	}
	void SyncBody()
	{
		if (ball.activeSelf)
		{
			_ballHealth.SyncHealth(_humanHealth);
			// transform.position = human.transform.position;
			ball.transform.position = human.transform.position;
			return;
		}
		else
		{
			// transform.position = ball.transform.position;
			_humanHealth.SyncHealth(_ballHealth);
			human.transform.position = ball.transform.position;
		}
	}
}
