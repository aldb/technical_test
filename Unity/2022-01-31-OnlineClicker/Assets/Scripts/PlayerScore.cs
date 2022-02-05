using TMPro;
using UnityEngine;

namespace clicker
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textbox;
        [SerializeField] private Game game;
        private int _score;

        private void OnEnable()
        {
            _textbox.SetText(_score.ToString());
        }

        public void IncreaseScore()
        {
            game.incrementRessourcesOnClick();
            _score=game.ressources;
            _textbox.SetText(_score.ToString());
        }

        public void updateScore() {
            _score = game.ressources;
            _textbox.SetText(_score.ToString());
        }

    }
}
