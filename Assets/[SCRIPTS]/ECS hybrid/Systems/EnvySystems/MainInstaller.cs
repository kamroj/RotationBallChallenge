using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    [SerializeField]
    BallComponents ball;

    public override void InstallBindings()
    {
        Container.Bind<BallComponents>().FromInstance(ball).AsSingle();
        Container.Bind<EnvyRotationHandler>().AsSingle();
        Container.Bind<PlayerMovementHandler>().AsSingle();
        //Container.Bind<BallComponents>().AsSingle();
    }
}