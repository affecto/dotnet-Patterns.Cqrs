// ReSharper disable ObjectCreationAsStatement

using System;
using Affecto.Patterns.Cqrs.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Affecto.Patterns.Cqrs.Tests
{
    [TestClass]
    public class EnvelopeTests
    {
        private TestCommand command;
        private const string CorrelationId = "correlation";

        [TestInitialize]
        public void Setup()
        {
            command = new TestCommand();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BodyCannotBeNull()
        {
            new Envelope<TestCommand>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FactoryBodyCannotBeNull()
        {
            Envelope.Create<TestCommand>(null);
        }

        [TestMethod]
        public void BodyIsSet()
        {
            Envelope<TestCommand> sut = new Envelope<TestCommand>(command);

            Assert.AreSame(command, sut.Body);
        }

        [TestMethod]
        public void BodyIsSetFromFactory()
        {
            Envelope<ICommand> sut = Envelope.Create(command);

            Assert.AreSame(command, sut.Body);
        }

        [TestMethod]
        public void CorrelationIdIsSet()
        {
            Envelope<TestCommand> sut = new Envelope<TestCommand>(command, CorrelationId);

            Assert.AreSame(CorrelationId, sut.CorrelationId);
        }

        [TestMethod]
        public void CorrelationIdIsSetFromFactory()
        {
            Envelope<ICommand> sut = Envelope.Create(command, CorrelationId);

            Assert.AreSame(CorrelationId, sut.CorrelationId);
        }
    }
}