using UnityEngine;
using Zenject;
using RotationBall.LevelChange;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    [SerializeField] GameObject levelChanger;

    public override void InstallBindings()
    {
        Container.Bind<LevelChanger>().FromComponentInNewPrefab(levelChanger).AsSingle();
    }
}
