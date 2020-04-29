
using System;
using UnityEngine;

namespace Game.LevelSystem.Base
{
    public class EndPlatform : PlatformBase
    {
        public override PlatformType PlatformType => PlatformType.FINISH;

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}
