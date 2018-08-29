using UnityEngine;
using Zenject;
using RotationBall;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    [SerializeField] BallComponents ball;
    [SerializeField] PlayerInputController playerInputController;

    public override void InstallBindings()
    {
        Container.Bind<BallComponents>().FromInstance(ball).AsSingle();
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        Container.Bind<PlayerInputController>().FromInstance(playerInputController).AsSingle();
        Container.Bind<EnvyRotationHandler>().AsSingle();
        Container.Bind<PlayerMovementHandler>().AsCached();

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<BallTouchedColliderSignal>();

        Container.BindInterfacesTo<PlayerMovementHandler>().AsCached();
        
    }
}