using UnityEngine;
using Zenject;
using RotationBall.LevelChange;
using RotationBall;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    [SerializeField] GameObject levelChanger;

    public override void InstallBindings()
    {
        //Container.BindInterfacesTo<GameController>().AsCached();
        //Container.Bind<GameController>().AsCached();
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

        Container.Bind<LevelChanger>().FromComponentInNewPrefab(levelChanger).AsSingle();
    }
}
