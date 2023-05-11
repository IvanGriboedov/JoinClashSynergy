using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "EnterGymState", menuName = "ScriptableObjects/GameStates/EnterGymState")]
	public class BootstrapState : IGameState
	{
		private readonly Scene _level;
		private readonly Scene _menu;

		private readonly IAsyncSceneLoading _sceneLoading;

		public BootstrapState(Scene level, Scene menu, IAsyncSceneLoading sceneLoading)
		{
			_level = level;
			_menu = menu;
			_sceneLoading = sceneLoading;
		}

		public void Enter()
		{
			_sceneLoading.LoadAsync(_level);
			_sceneLoading.LoadAsync(_menu);
		}

		public void Exit()
		{
		}
	}
}