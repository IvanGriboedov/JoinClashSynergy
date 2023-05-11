using System;
using GameStates.Base;
using GameStates.States;
using StaticContext;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
	public class Bootstrap : MonoBehaviour
	{

		[SerializeField] private GameStateMachineFactory _stateMachineFactory;
		
		private void OnEnable()
		{
			IGameStateMachine stateMachine = _stateMachineFactory.Initialize();
			Instance<IGameStateMachine>.Value = stateMachine;
			stateMachine.Enter<BootstrapState>();
		}
	}
}