using Helios.Context;
using Helios.Context.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


    public class Auth
    {
        private String Email { get; set; }
        public readonly HeliosContext helios;

        public Auth(HeliosContext helios, String UniqueIdentifier)
        {
            this.helios = helios;
            this.Email = UniqueIdentifier;
        }

        private Utilisateur? _user;
        public async Task<Utilisateur> User()
        {
            if (_user == null)
                _user = await FindUserByEmail();
            if (_user == null)
                throw new ApiException("Email not found");
            return _user;

        }

        public async Task<Utilisateur> GetUserInfo()
        {
            return await User();
        }

        public async Task<Utilisateur?> FindUserByEmail()
        {

            return await helios.Utilisateurs
                .FirstOrDefaultAsync(x => x.Email == Email);
        }

        public async Task<Boolean> VerifyUserPassword(String password)
        {
            // Vérification du mot de passe
            var passwordHasher = new PasswordHasher<Utilisateur>();
            var user = await User();
            if (String.IsNullOrEmpty(user.MotDePasse))
                throw new ApiException("Password not set");
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.MotDePasse, password);
            if (verificationResult == PasswordVerificationResult.Success)
                return true;
            if (verificationResult == PasswordVerificationResult.Failed)
                return false;
            if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.MotDePasse = passwordHasher.HashPassword(user, password);
                await helios.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ClaimsIdentity> getUserClaims(String password)
        {

            if (await VerifyUserPassword(password) == false)
                throw new ApiException("Invalid password");
            return await GenerateClaims();
        }


        private async Task<ClaimsIdentity> GenerateClaims()
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.UniqueName,Email),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,Email),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(Jwt.expireMinutes)).ToUnixTimeSeconds()}"),
        };
            var _user = await User();
            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        }

#if DEBUG
        public Task<ClaimsIdentity> GenerateClaimsForDebug() => GenerateClaims();
#endif
    }

