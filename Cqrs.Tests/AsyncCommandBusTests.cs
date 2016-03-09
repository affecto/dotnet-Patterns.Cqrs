// ReSharper disable ObjectCreationAsStatement

using System;
using Affecto.Patterns.Cqrs.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Affecto.Patterns.Cqrs.Tests
{
    [TestClass]
    public class AsyncCommandBusTests
    {
        private TestCommand command;
        private IAsyncCommandHandler<TestCommand> commandHandler;
        private ICommandHandlerResolver commandHandlerResolver;
        private AsyncCommandBus sut;

        [TestInitialize]
        public void Setup()
        {
            command = new TestCommand();
            commandHandler = Substitute.For<IAsyncCommandHandler<TestCommand>>();
            
            commandHandlerResolver = Substitute.For<ICommandHandlerResolver>();
            commandHandlerResolver.ResolveCommandHandler<IAsyncCommandHandler<TestCommand>>().Returns(commandHandler);

            sut = new AsyncCommandBus(commandHandlerResolver);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ResolverCannotBeNull()
        {
            new CommandBus(null);
        }

        [TestMethod]
        public void EnvelopeCannotBeNull()
        {
            try
            {
                sut.SendAsync(null).Wait();
                Assert.Fail();
            }
            catch (AggregateException e)
            {
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void CommandIsHandled()
        {
            sut.SendAsync(Envelope.Create(command)).Wait();
            commandHandler.Received().ExecuteAsync(command);
        }
    }
}