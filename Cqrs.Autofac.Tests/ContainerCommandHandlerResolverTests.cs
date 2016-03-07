using System;
using Affecto.Patterns.Cqrs.Autofac.Tests.TestHelpers;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Affecto.Patterns.Cqrs.Autofac.Tests
{
    [TestClass]
    public class ContainerCommandHandlerResolverTests
    {
        private IContainer container;
        private ContainerCommandHandlerResolver sut;

        [TestMethod]
        public void OneCommandHandlerIsResolved()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestCommandHandler>().As<ICommandHandler<TestCommand>>();
            builder.RegisterType<SecondTestCommandHandler>().As<ICommandHandler<SecondTestCommand>>();
            container = builder.Build();

            sut = new ContainerCommandHandlerResolver(container);
            ICommandHandler<TestCommand> commandHandler = sut.ResolveCommandHandler(new TestCommand());

            Assert.IsInstanceOfType(commandHandler, typeof(TestCommandHandler));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionIfNoHandlersRegistered()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SecondTestCommandHandler>().As<ICommandHandler<SecondTestCommand>>();
            container = builder.Build();

            sut = new ContainerCommandHandlerResolver(container);
            sut.ResolveCommandHandler(new TestCommand());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionIfMoreThanOneHandlerRegistered()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestCommandHandler>().As<ICommandHandler<TestCommand>>();
            builder.RegisterType<AnotherTestCommandHandler>().As<ICommandHandler<TestCommand>>();
            builder.RegisterType<SecondTestCommandHandler>().As<ICommandHandler<SecondTestCommand>>();
            container = builder.Build();

            sut = new ContainerCommandHandlerResolver(container);
            sut.ResolveCommandHandler(new TestCommand());
        }
    }
}