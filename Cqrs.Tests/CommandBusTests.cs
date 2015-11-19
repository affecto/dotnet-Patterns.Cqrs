using System;
using Affecto.Patterns.Cqrs.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Affecto.Patterns.Cqrs.Tests
{
    [TestClass]
    public class CommandBusTests
    {
        private TestCommand command;
        private ICommandHandler<TestCommand> commandHandler;
        private ICommandHandlerResolver commandHandlerResolver;
        private CommandBus sut;

        [TestInitialize]
        public void Setup()
        {
            command = new TestCommand();
            commandHandler = Substitute.For<ICommandHandler<TestCommand>>();
            
            commandHandlerResolver = Substitute.For<ICommandHandlerResolver>();
            commandHandlerResolver.Resolve(command).Returns(commandHandler);

            sut = new CommandBus(commandHandlerResolver);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ResolverCannotBeNull()
        {
            new CommandBus(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnvelopeCannotBeNull()
        {
            sut.Send(null);
        }

        [TestMethod]
        public void CommandIsHandled()
        {
            sut.Send(Envelope.Create(command));
            commandHandler.Received().Execute(command);
        }
    }
}