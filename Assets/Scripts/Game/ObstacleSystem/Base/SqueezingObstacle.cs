using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.ObstacleSystem.ObstaclePiece;

namespace Game.ObstacleSystem.Base
{
    public class SqueezingObstacle : ObstacleBase
    {
        public override ObstacleType ObstacleType => ObstacleType.SQUEEZING;
        private Tween _moveTweenRight;
        private Tween _moveTweenLeft;
        
        private List<MovePiece> _movePieces;

        public override void Initialize()
        {
            _movePieces = GetComponentsInChildren<MovePiece>().ToList();
            StartMovingObjects();
        }

        private void StartMovingObjects()
        {
            _moveTweenRight?.Kill();
            _moveTweenRight = _movePieces[0].transform
                .DOLocalMoveX(_movePieces[0].transform.localPosition.x - 0.5f, 1f / (Speed/10))
                .SetLoops(-1, LoopType.Yoyo);
         
            
            _moveTweenLeft?.Kill();
            _moveTweenLeft = _movePieces[1].transform
                .DOLocalMoveX(_movePieces[1].transform.localPosition.x + 0.5f, 1f / (Speed/10))
                .SetLoops(-1, LoopType.Yoyo);
        }

    }
}
