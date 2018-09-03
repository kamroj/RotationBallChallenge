using UnityEngine;
using Zenject;
using RotationBall;
using RotationBall.LevelChange;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    [SerializeField] BallComponents ball;
    [SerializeField] PlayerInputController playerInputController;
    [SerializeField] ChangeSceneByZoomView camera;
    [SerializeField] CheckIfObjectIsGrounded checkIfObjectIsGrounded;
    [SerializeField] ParticleComponentList jumpingParticles;

    public override void InstallBindings()
    {
        Container.Bind<BallComponents>().FromInstance(ball).AsSingle();
        Container.Bind<ParticleComponentList>().FromInstance(jumpingParticles).AsSingle();
        Container.Bind<CheckIfObjectIsGrounded>().FromInstance(checkIfObjectIsGrounded).AsSingle();
        Container.Bind<ChangeSceneByZoomView>().FromInstance(camera).AsSingle();
        //Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        Container.Bind<PlayerInputController>().FromInstance(playerInputController).AsSingle();
        Container.Bind<EnvyRotationHandler>().AsSingle();
        Container.Bind<PlayerMovementHandler>().AsCached();

        Container.BindInterfacesAndSelfTo<Hole>().AsSingle();
        

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<BallTouchedColliderSignal>();

        Container.BindInterfacesTo<PlayerMovementHandler>().AsCached();
        
    }
}