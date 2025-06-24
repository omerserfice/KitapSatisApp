namespace KitapSatisApp.Application.Features.Auth
{
	public class JwtSettings
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public int DurationMinutes { get; set; }
		
	}

}
