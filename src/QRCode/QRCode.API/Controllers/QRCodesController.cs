using QRCoder;

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

            string text = string.Join("\n", result);
            byte[] QRCode = new byte[0];

            if (!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator generator = new QRCodeGenerator();
                QRCodeData data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
                QRCode = bitmap.GetGraphic(20);
            }

            string QRCodeAsImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCode)}";

            return Ok(QRCodeAsImageBase64);
        }
    }
}

