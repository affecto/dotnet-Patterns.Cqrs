namespace Affecto.Patterns.Cqrs.Autofac.Tests.TestHelpers
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public void Execute(TestCommand command)
        {
        }
    }
}