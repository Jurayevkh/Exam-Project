using Microsoft.AspNetCore.Mvc.RazorPages;
using static QRCoder.PayloadGenerator;

namespace QRCodes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QRCodesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetQRCode()
        {

            var result = await _mediator.Send(new GetAllUsersQuery());

            //string text = "https://github.com/Jurayevkh?tab=repositories";
            string text = "";
            foreach (var item in result)
            {
                text += $"{item.FirstName} , {item.LastName} ,Age: {item.Age}, Email: {item.Email}\n";
            }

            byte[] QRCode = new byte[0];

            if (!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator generator = new QRCodeGenerator();
                QRCodeData data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.M);
                BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
                QRCode = bitmap.GetGraphic(20);
            }

            return File(QRCode,"image/png");

        }
    }
}

