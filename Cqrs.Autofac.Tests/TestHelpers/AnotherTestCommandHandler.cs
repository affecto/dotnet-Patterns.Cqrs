namespace Affecto.Patterns.Cqrs.Autofac.Tests.TestHelpers
{
    public class AnotherTestCommandHandler : ICommandHandler<TestCommand>
    {
        public void Execute(TestCommand command)
        {
        }
    }
}