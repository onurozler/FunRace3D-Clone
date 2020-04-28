using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.ObstacleSystem.ObstaclePiece;

namespace Game.ObstacleSystem.Base
{
    public class SqueezingObstacle : ObstacleBase
    {
        private Tween _moveTweenRight;
        private Tween _moveTweenLeft;
        
        private List<MovePiece> _movePieces;

        private void Awake()
        {
            _movePieces = GetComponentsInChildren<MovePiece>().ToList();
            
            StartMovingObjects();
        }

        private void StartMovingObjects()
        {
            _movePieces[0].transform.DOLocalMoveX(_movePieces[0].transform.localPosition.x - 0.3f, 0.5f / (Speed/10) ).OnComplete(() =>
            {
                _moveTweenRight?.Kill();
                _moveTweenRight = _movePieces[0].transform
                    .DOLocalMoveX(_movePieces[0].transform.localPosition.x + 0.3f, 0.5f / (Speed/10))
                    .SetLoops(-1, LoopType.Yoyo);
            });
            
            _movePieces[1].transform.DOLocalMoveX(_movePieces[1].transform.localPosition.x + 0.3f, 0.5f / (Speed/10) ).OnComplete(() =>
            {
                _moveTweenLeft?.Kill();
                _moveTweenLeft = _movePieces[1].transform
                    .DOLocalMoveX(_movePieces[1].transform.localPosition.x - 0.3f, 0.5f / (Speed/10))
                    .SetLoops(-1, LoopType.Yoyo);
            });
        }
    }
}
