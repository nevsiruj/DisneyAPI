using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// PUNTO 2 (AUTENTICACION DE USUARIOS) & PUNTO 11 (EMAIL DE BIENVENIDA)


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserMail = request.UserMail;   
            user.PasswordHash = passwordHash;   
            user.PasswordSalt = passwordSalt;

         
            // Send Email To Email User Register//           
            string Servidor = "smtp.gmail.com";
            int Puerto = 587;
            String GmailUser = "email@email.com";
            String GmailPass = "password";
            

            MimeMessage mensaje = new();
            mensaje.From.Add(new MailboxAddress("Welcome Dear!", GmailUser));
            mensaje.To.Add(new MailboxAddress("Destino", user.UserMail));
            mensaje.Subject = "Hola desde C# con MailKit";

            BodyBuilder CuerpoMensaje = new();
            CuerpoMensaje.TextBody = "Hola";
            CuerpoMensaje.HtmlBody = "Hola, <b> Bienvenido al Mundo de Disney </b>";

            mensaje.Body = CuerpoMensaje.ToMessageBody();

            SmtpClient ClienteSmtp = new();
            ClienteSmtp.CheckCertificateRevocation = false;
            ClienteSmtp.Connect(Servidor, Puerto, MailKit.Security.SecureSocketOptions.StartTls);
            ClienteSmtp.Authenticate(GmailUser, GmailPass);
            ClienteSmtp.Send(mensaje);
            ClienteSmtp.Disconnect(true);

            ///////

            return Ok(user);

                

        }

        

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.UserMail != request.UserMail)
            {
                return BadRequest("User not found.");
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserMail)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt )
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));   
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash); 
            }
        }
    }
}
