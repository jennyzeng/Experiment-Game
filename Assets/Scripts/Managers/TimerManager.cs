using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimerManager : BaseManager
{
	public List<Timer> CurrentTimers;// = new List<Timer>();
		
	public override void Initialize(){
		CurrentTimers = new List<Timer>();
	}
	void Update ()
	{
		//if (Game.isPaused)
		//    return;

		foreach (Timer timer in CurrentTimers.ToArray())
		{
			timer.Tick(Time.deltaTime);
			if (timer.IsFinished)
			{
				CurrentTimers.Remove(timer);
			}
		}
	}

	public void AddTimer(float duration, GameObject go, Action callback,
						 float interval = 0, int repeat = 0)
	{
		CurrentTimers.Add(new Timer(duration, go, callback, interval, repeat));
	}
	public void AddTimer (Timer timer)
	{
		CurrentTimers.Add(timer);
	}

	public void RemoveTimer(Timer timer)
	{
		CurrentTimers.Remove(timer);
	}
}