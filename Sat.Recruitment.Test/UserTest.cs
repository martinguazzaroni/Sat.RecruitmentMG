using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserTest
    {
        [Fact]
        public void ValidMikeCreated()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void ValidAgustinaDuplicated()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.Equal(false, result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void ValidNewUserCreated()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Josesito", "Josesito@gmail.com", "Av. JOSE G", "+349 1122354222", "Normal", "124").Result;

            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }
    }
}
