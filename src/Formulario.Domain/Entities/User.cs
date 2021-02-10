using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Formulario.Infra.CrossCutting.Auth.Facades;
using Formulario.Domain.Interfaces.Identities;
using Formulario.Domain.ViewModels.User;
using Formulario.Infra.CrossCutting.GenericHelpers;
using Formulario.Domain.Repositories;

namespace Formulario.Domain.Entities
{
    public class User : IUser
    {
        private readonly ITokenFacade _facadeToken;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repositoryUser;

        public User(ITokenFacade facadeToken, 
                    IConfiguration configuration,
                    IUserRepository repositoryUser)
        {
            _facadeToken = facadeToken;
            _configuration = configuration;
            _repositoryUser = repositoryUser;
        }

        public User()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        
        #region Properties

        private Guid Id { get; set; }

        private DateTime CreatedDate { get; set; }

        private DateTime? LastModified { get; set; }

        private bool IsDeleted {get;set;}

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        #endregion

        public dynamic Auth(AuthViewModel auth)
        {
            var _key = _configuration.GetSection("PasswordKey")?.Get<string>();

            if(_key == null)
                throw new Exception("Password não configurado.");

            string _encryptedPassword = auth.Password.EncryptString(_key);

            User _user = _repositoryUser.Find(wh => wh.IsDeleted 
                                                    && wh.Email == auth.Email
                                                    && wh.Password == _encryptedPassword);

            if(_user == null)
                throw new Exception("Usuário não encontrado");

            return new {
                token =_facadeToken.GenerateToken(_user),
                user = _user
            };
        }

        public dynamic Create(CreateViewModel user){

            if (user == null)
                throw new Exception("Informaçẽos inválidas.");

            var _key = _configuration.GetSection("PasswordKey")?.Get<string>();

            if(_key == null)
                throw new Exception("Password não configurado.");

            User _user = new User
            {
                Name = user.UserName,
                Email = user.Email,
                Password = user.Password.EncryptString(_key)
            };

            return _repositoryUser.Create(_user);
        }
    }
}