using Autofac;

namespace Affecto.Patterns.Cqrs.Autofac
{
    public class CqrsModule : Module
    {
        /// <summary>
        /// Adds registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ContainerCommandHandlerResolver>().As<ICommandHandlerResolver>();
            builder.RegisterType<CommandBus>().As<ICommandBus>();
            builder.RegisterType<AsyncCommandBus>().As<IAsyncCommandBus>();
        }
    }
}