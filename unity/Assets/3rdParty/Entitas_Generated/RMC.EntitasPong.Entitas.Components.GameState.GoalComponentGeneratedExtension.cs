//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public RMC.EntitasPong.Entitas.Components.GameState.GoalComponent goal { get { return (RMC.EntitasPong.Entitas.Components.GameState.GoalComponent)GetComponent(ComponentIds.Goal); } }

        public bool hasGoal { get { return HasComponent(ComponentIds.Goal); } }

        public Entity AddGoal(int newPointsPerGoal) {
            var component = CreateComponent<RMC.EntitasPong.Entitas.Components.GameState.GoalComponent>(ComponentIds.Goal);
            component.pointsPerGoal = newPointsPerGoal;
            return AddComponent(ComponentIds.Goal, component);
        }

        public Entity ReplaceGoal(int newPointsPerGoal) {
            var component = CreateComponent<RMC.EntitasPong.Entitas.Components.GameState.GoalComponent>(ComponentIds.Goal);
            component.pointsPerGoal = newPointsPerGoal;
            ReplaceComponent(ComponentIds.Goal, component);
            return this;
        }

        public Entity RemoveGoal() {
            return RemoveComponent(ComponentIds.Goal);
        }
    }

    public partial class Pool {
        public Entity goalEntity { get { return GetGroup(Matcher.Goal).GetSingleEntity(); } }

        public RMC.EntitasPong.Entitas.Components.GameState.GoalComponent goal { get { return goalEntity.goal; } }

        public bool hasGoal { get { return goalEntity != null; } }

        public Entity SetGoal(int newPointsPerGoal) {
            if (hasGoal) {
                throw new EntitasException("Could not set goal!\n" + this + " already has an entity with RMC.EntitasPong.Entitas.Components.GameState.GoalComponent!",
                    "You should check if the pool already has a goalEntity before setting it or use pool.ReplaceGoal().");
            }
            var entity = CreateEntity();
            entity.AddGoal(newPointsPerGoal);
            return entity;
        }

        public Entity ReplaceGoal(int newPointsPerGoal) {
            var entity = goalEntity;
            if (entity == null) {
                entity = SetGoal(newPointsPerGoal);
            } else {
                entity.ReplaceGoal(newPointsPerGoal);
            }

            return entity;
        }

        public void RemoveGoal() {
            DestroyEntity(goalEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGoal;

        public static IMatcher Goal {
            get {
                if (_matcherGoal == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Goal);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGoal = matcher;
                }

                return _matcherGoal;
            }
        }
    }
}
