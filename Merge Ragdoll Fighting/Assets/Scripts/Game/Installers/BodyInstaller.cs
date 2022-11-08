using UnityEngine;
using RootMotion.Dynamics;
using Animancer;
using Zenject;
using Game.Utilities;

namespace Game.Installers
{
    public class BodyInstaller : MonoInstaller
    {
        [SerializeField] private PuppetMaster _body;
        [SerializeField] private Transform _enemyTransform;
        [SerializeField] private Vector3 _hitDimensions;
        [SerializeField] private Animator _hitAnimator;
        [SerializeField] private AnimationClip _limbRequiredAnimation;
        [SerializeField] private LayerMask _enemyLayer;

        public override void InstallBindings()
        {
            BindBody(_body);
            BindEnemyTransform(_enemyTransform);
            BindHitDimensions(_hitDimensions);
            BindHitAnimator(_hitAnimator);
            BindLimbAnimation(_limbRequiredAnimation);
            BindEnemyLayer(_enemyLayer);
            BindDiContainerDecorator(new Decorator<DiContainer>(Container));
        }

        private void BindBody(PuppetMaster body)
        {
            Container.Bind<PuppetMaster>().FromInstance(body).AsSingle().NonLazy();
        }

        private void BindEnemyTransform(Transform enemy)
        {
            Container.Bind<Transform>().FromInstance(enemy).AsSingle().NonLazy();
        }

        private void BindHitDimensions(Vector3 hitDimensions)
        {
            Container.Bind<Vector3>().FromInstance(hitDimensions).AsSingle().NonLazy();
        }

        private void BindHitAnimator(Animator hitAnimator)
        {
            Container.Bind<Animator>().FromInstance(hitAnimator).AsSingle().NonLazy();
        }

        private void BindEnemyLayer(LayerMask enemy)
        {
            Container.Bind<LayerMask>().FromInstance(enemy).AsSingle().NonLazy();
        }

        private void BindLimbAnimation(AnimationClip limbAnimation)
        {
            Container.Bind<AnimationClip>().FromInstance(limbAnimation).AsSingle().NonLazy();
        }

        private void BindDiContainerDecorator(Decorator<DiContainer> containerDecorator)
        {
            Container.Bind<Decorator<DiContainer>>().FromInstance(containerDecorator).AsSingle().NonLazy();
        }
    }
}
