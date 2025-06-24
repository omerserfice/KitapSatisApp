using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatisApp.Application.Features.Auth.Dto
{
	public record AuthRegisterResponse(bool IsSuccessful,int StatusCode, string Message);
}
