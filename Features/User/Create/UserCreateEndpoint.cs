using FastEndpoints;

namespace MyWebApp.Features.User.Create
{
    public class UserCreateEndpoint : Endpoint<UserCreateRequest, UserCreateResponse>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            Policies("user:create");
        }

        public override async Task HandleAsync(UserCreateRequest req, CancellationToken ct)
        {
            await SendAsync(new()
            {
                FullName = req.FirstName + " " + req.LastName,
                IsOver18 = req.Age > 18
            });
        }
    }
}
