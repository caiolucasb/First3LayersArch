using System;
using IST.BLL.Services;
using Xunit;

namespace IST.BLL.TEST.Services
{
    public class ValidationsTest
    {
        private readonly ValidationsBLL _validation;
        public ValidationsTest()
        {
            _validation = new ValidationsBLL();
        }

        [Theory]
        [InlineData("caio@hotmail.com", true)]
        [InlineData("caio@outlook.com", true)]
        [InlineData("caio@hotmail.", false)]
        [InlineData("caio   @hotmail", false)]
        public void ShouldPassJustValidEmail(string email,bool expected)
        {
            var result = _validation.IsValidEmail(email);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("caio")]
        [InlineData("caio.lucas")]
        public void ShouldThrowAnExceptionWhenPassAWrongEmail(string email)
        {
            Action act = () =>  _validation.IsValidEmail(email);
            Assert.Throws<FormatException>(act);
        }

        [Theory]
        [InlineData("Caio", true)]
        [InlineData("Caio Lucas", true)]
        [InlineData("12345", false)]
        [InlineData("Caio@", false)]
        public void ShouldPassJustValidName(string name, bool expected)
        {
            var result = _validation.IsValidName(name);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(100, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]    
        public void ShouldPassJustValidId(int id, bool expected)
        {
            var result = _validation.IsAValidId(id);
            Assert.Equal(result, expected);
        }
    }
}
