using MediatR;

namespace GoogleTagManagerWebApp.Models
{
    public class GoogleTagManagerCommand : IRequest<bool>
    {
        public string ServerUrl { get; set; }
        public string GtmId { get; set; }
        public string EventName { get; set; }
        public string Value { get; set; }
    }

    public class GoogleTagManagerHandler : IRequestHandler<GoogleTagManagerCommand, bool>
    {
        private readonly HttpClient _httpClient;
        private readonly IGoogleTagManagerLinkFactory _googleTagManagerLinkFactory;
        public GoogleTagManagerHandler(IHttpClientFactory clientFactory, IGoogleTagManagerLinkFactory googleTagManagerLinkFactory)
        {
            _googleTagManagerLinkFactory = googleTagManagerLinkFactory;
            _httpClient = clientFactory.CreateClient(nameof(GoogleTagManagerCommand));
        }

        public async Task<bool> Handle(GoogleTagManagerCommand request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(_googleTagManagerLinkFactory.Get(null, request.EventName), cancellationToken);

            return response.IsSuccessStatusCode;
        }
    }
}
