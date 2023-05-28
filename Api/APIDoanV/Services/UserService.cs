using APIDoanV.Models;
using APIDoanV.helper;
using System.IdentityModel.Tokens.Jwt;
using APIDoanV.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace APIDoanV.Services
{
    public interface IUserService
    {
        Users Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        ApiContext db = new ApiContext();
        private readonly AppSettings _appSettings;

        public Users Authenticate(string username, string pass)
        {
            var result = from t in db.Accounts
                         join n in db.Users on t.MaNguoiDung equals n.Id
                         select new Users { Role = t.LoaiQuyen, MaNguoiDung = t.MaNguoiDung, TaiKhoan = t.TaiKhoan, HoTen = n.FullName, MatKhau = t.MatKhau, DiaChi = n.Address, DienThoai = n.Phone, Email = n.Email };
            var user = result.SingleOrDefault(x=>x.TaiKhoan==username && x.MatKhau==pass);
            if (user ==null)
            {
                return null;
            }
             var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new(new Claim[] {
                  new Claim(ClaimTypes.NameIdentifier, user.TaiKhoan.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.DienThoai.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user.WithoutPassword();
        }
    }
   
}
