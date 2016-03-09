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
        private List<ICommandHandler> commandHandlers;
        private CommandHandlerResolver sut;

        [TestInitialize]
        public void Setup()
        {
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
            sut.ResolveCommandHandler<ICommandHandler<TestCommand>>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MoreThanOneCommandHandlerRegisteredThrowsException()
        {
            commandHandlers.Add(Substitute.For<ICommandHandler<TestCommand>>());
            commandHandlers.Add(Substitute.For<ICommandHandler<TestCommand>>());
            sut.ResolveCommandHandler<ICommandHandler<TestCommand>>();
        }

        [TestMethod]
        public void SingleRegisteredCommandHandlerIsReturned()
        {
            ICommandHandler<TestCommand> commandHandler = Substitute.For<ICommandHandler<TestCommand>>();
            commandHandlers.Add(commandHandler);

            ICommandHandler<TestCommand> result = sut.ResolveCommandHandler<ICommandHandler<TestCommand>>();

            Assert.AreSame(commandHandler, result);
        }
    }
}