// ReSharper disable ObjectCreationAsStatement

using System;
using System.Collections.Generic;
using Affecto.Patterns.Cqrs.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Affecto.Patterns.Cqrs.Tests
{
    [TestClass]
    public class CommandHandlerResolverTests
    {
        private TestCommand command;
        private List<ICommandHandler> commandHandlers;
        private CommandHandlerResolver sut;

        [TestInitialize]
        public void Setup()
        {
            command = new TestCommand();
            commandHandlers = new List<ICommandHandler>();

            sut = new CommandHandlerResolver(commandHandlers);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ResolversCannotBeNull()
        {
            new CommandHandlerResolver(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoCommandHandlersRegisteredThrowsException()
        {
            sut.Resolve(command);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MoreThanOneCommandHandlerRegisteredThrowsException()
        {
            commandHandlers.Add(Substitute.For<ICommandHandler<TestCommand>>());
            commandHandlers.Add(Substitute.For<ICommandHandler<TestCommand>>());
            sut.Resolve(command);
        }

        [TestMethod]
        public void SingleRegisteredCommandHandlerIsReturned()
        {
            ICommandHandler<TestCommand> commandHandler = Substitute.For<ICommandHandler<TestCommand>>();
            commandHandlers.Add(commandHandler);

            ICommandHandler<TestCommand> result = sut.Resolve(command);

            Assert.AreSame(commandHandler, result);
        }
    }
}