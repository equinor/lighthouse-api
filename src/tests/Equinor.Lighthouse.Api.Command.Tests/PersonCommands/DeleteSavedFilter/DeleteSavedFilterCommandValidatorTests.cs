using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.PersonCommands.DeleteSavedFilter;
using Equinor.Lighthouse.Api.Command.Validators;
using Equinor.Lighthouse.Api.Command.Validators.SavedFilterValidators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Equinor.Lighthouse.Api.Command.Tests.PersonCommands.DeleteSavedFilter
{
    [TestClass]
    public class DeleteSavedFilterCommandValidatorTests
    {
        private DeleteSavedFilterCommandValidator _dut;
        private Mock<ISavedFilterValidator> _savedFilterValidatorMock;
        private Mock<IRowVersionValidator> _rowVersionValidatorMock;
        private DeleteSavedFilterCommand _command;

        private readonly Guid _savedFilterId = new("1");

        [TestInitialize]
        public void Setup_OkState()
        {
            const string RowVersion = "AAAAAAAAJ00=";
            _savedFilterValidatorMock = new Mock<ISavedFilterValidator>();
            _savedFilterValidatorMock.Setup(r => r.ExistsAsync(_savedFilterId, default))
                .Returns(Task.FromResult(true));
            _rowVersionValidatorMock = new Mock<IRowVersionValidator>();
            _rowVersionValidatorMock.Setup(r => r.IsValid(RowVersion)).Returns(true);

            _command = new DeleteSavedFilterCommand(_savedFilterId, RowVersion);

            _dut = new DeleteSavedFilterCommandValidator(
                _savedFilterValidatorMock.Object,
                _rowVersionValidatorMock.Object);
        }

        [TestMethod]
        public void Validate_ShouldBeValid_WhenOkState()
        {
            var result = _dut.Validate(_command);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Validate_ShouldFail_WhenSavedFilterNotExists()
        {
            _savedFilterValidatorMock.Setup(r => r.ExistsAsync(_savedFilterId, default)).Returns(Task.FromResult(false));

            var result = _dut.Validate(_command);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].ErrorMessage.StartsWith("Saved filter doesn't exist!"));
        }

        [TestMethod]
        public void Validate_ShouldFail_WhenInvalidRowVersion()
        {
            const string invalidRowVersion = "String";

            var command = new DeleteSavedFilterCommand(_savedFilterId, invalidRowVersion);
            _rowVersionValidatorMock.Setup(r => r.IsValid(invalidRowVersion)).Returns(false);

            var result = _dut.Validate(command);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].ErrorMessage.StartsWith("Not a valid row version!"));
        }
    }
}
