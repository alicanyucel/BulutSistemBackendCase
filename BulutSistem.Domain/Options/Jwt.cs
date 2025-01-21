
namespace BulutSistem.Domain.Options
{
    public sealed class Jwt
    {
        public string Issuer { get; set; } = default!; // warning vermemesi için
        public string Audience { get; set; } = default!;// warning vermemesi için
        public string SecretKey { get; set; } = default!;// warning vermemesi için
    }
}
