namespace Affecto.Patterns.Cqrs.Autofac.Tests.TestHelpers
{
    public class SecondTestCommandHandler : ICommandHandler<SecondTestCommand>
    {
        public void Execute(SecondTestCommand command)
        {
        }
    }
}