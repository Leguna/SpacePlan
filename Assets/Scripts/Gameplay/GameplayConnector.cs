using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.SaveGame;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship;
using UnityEngine;

namespace SpacePlan.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private SaveDataController _saveData;
        private SoundFxController _soundFx;
        private SpaceshipController _spaceshipController;

        private void OnUpdateCoin(UpdateCoinMessage message)
        {
            _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        }

        private void OnMoveSpaceship(MovePlayerShipMessage message)
        {
            _spaceshipController.OnMoveInput(message.Direction);
        }

        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnUpdateCoin);
            Subscribe<MovePlayerShipMessage>(OnMoveSpaceship);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnUpdateCoin);
            Unsubscribe<MovePlayerShipMessage>(OnMoveSpaceship);
        }
    }
}