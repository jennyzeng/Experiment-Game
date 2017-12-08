using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySwitcher : PlayerAbility {

	public GameObject human;
	public GameObject ball;
	private PlayerHealth _ballHealth;
	private PlayerHealth _humanHealth;
	private bool _isHumanStatus;
	private Vector3 defaultOffset;
    public bool canSwitchToBall;

    public override void Action()
    {
        if (Input.GetButtonDown(axis))
		{
            if (!canSwitchToBall) return;
            _isHumanStatus = !_isHumanStatus;
			ActiveHumanStatus(_isHumanStatus);
			SyncBody();
		}
    }

	public GameObject GetcurBody()
	{
		if (_isHumanStatus)
		{
			return human;
		}
		else
		{
			return ball;
		}
	}

    // Use this for initialization
    protected override void Start () {
		base.Start();
		_humanHealth = human.GetComponent<PlayerHealth>();
		_ballHealth = ball.GetComponent<PlayerHealth>();
		_isHumanStatus = true;
		ActiveHumanStatus(_isHumanStatus);
		defaultOffset = ball.transform.position-human.transform.position;
        canSwitchToBall = false;
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
			ball.transform.position = human.transform.position+ defaultOffset;
			return;
		}
		else
		{
			_humanHealth.SyncHealth(_ballHealth);
			human.transform.position = ball.transform.position - defaultOffset;

		}
	}
}
