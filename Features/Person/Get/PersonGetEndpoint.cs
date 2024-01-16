using FastEndpoints;

namespace MyWebApp.Features.Person.Get
{
    public class PersonGetEndpoint : EndpointWithoutRequest<PersonGetResponse>
    {
        public override void Configure()
        {
            Get("/api/person");
            AllowAnonymous();
        }

        //public override async Task HandleAsync(CancellationToken ct)
        //{
        //    var person = await dbContext.GetFirstPersonAsync();

        //    Response.FullName = person.FullName;
        //    Response.Age = person.Age;
        //}

        //public override async Task HandleAsync(CancellationToken ct)
        //{
        //    Response.FullName = "Dinuth";
        //    Response.Age = 35;
        //}

        public override Task HandleAsync(CancellationToken ct)
        {
            Response = new()
            {
                FullName = "john doe",
                Age = 124
            };
            return Task.CompletedTask;
        }
    }
}
