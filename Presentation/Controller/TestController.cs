using Asp.Versioning;
using Contract.Enumerations;
using Contract.IntegrationEvent;
using Infrastructure.Authentication;
using Infrastructure.Redis;
using Infrastructure.Redis.Attributes;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Controller
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/Test")]
    public class TestController : APIController
    {
        private readonly IResponeCacheService _responeCacheService;
        private readonly IPublishEndpoint _publishEndpoint;
        public TestController(ISender sender, IResponeCacheService responeCacheService, IPublishEndpoint publishEndpoint) : base(sender)
        {
            _responeCacheService = responeCacheService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet()]
        [Cache(100)]
        [CustomAuthorize(1000, 101)]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Get()
        {
            var rn = new Random();
            var result = new List<Domain.Entities.TokenUsed>()
            {
                new Domain.Entities.TokenUsed() {TokenId = new Guid(), TokenValue = "11"},
                new Domain.Entities.TokenUsed() {TokenId = new Guid(), TokenValue = "11"},
                new Domain.Entities.TokenUsed() {TokenId = new Guid(), TokenValue = "11"},
                new Domain.Entities.TokenUsed() {TokenId = new Guid(), TokenValue = "11"},
            };
            return Ok(result);
        }
        [HttpPost()]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Create()
        {
            await _responeCacheService.RemoveCacheResponeAsync(HttpContext.Request.Path);
            return Ok();
        }
        [HttpPost("sms-noti")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> PublishSmsEvent()
        {
            await _publishEndpoint.Publish(new DomainEvent.SmsNotificationEvent
            {
                Id = new Guid(),
                Description = "This is my Test!",
                Name = "Just Tesst man!",
                TimeStamp = DateTime.Now,
                TransactionId = new Guid(),
                Type = NotificationType.sms,
            });
            return Accepted();
        }

    }
}
