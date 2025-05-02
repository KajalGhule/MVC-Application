using CRMLib;
using CRMService.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();  
var app = builder.Build();

//API's
app.MapGet("/api/customers", () =>
{
    ICustomerService customerService = new CustomerService();
    List<Customer> customerList = customerService.GetCustomers();
    return Results.Ok(customerList);
});

app.MapGet("/api/customers/{id}", (int id) =>
{
    ICustomerService customerService = new CustomerService();
    Customer customer = customerService.GetCustomerById(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound("Customer not found");
});

app.MapPost("/api/customers", (Customer customer) =>
{
    ICustomerService customerService = new CustomerService();
    bool status = customerService.AddCustomer(customer);
    if (status)
        return Results.Created($"/api/customers/{customer.Id}", customer);
    else
        return Results.BadRequest("Customer could not be added.");
});

app.MapPut("/api/customers", (Customer customer) =>
{
    ICustomerService customerService = new CustomerService();
    bool status = customerService.UpdateCustomer(customer);
    if (status)
        return Results.Ok(customer);
    else
        return Results.BadRequest("Customer could not be updated.");
});

app.MapDelete("/api/customers/{id}", (int id) =>
{
    ICustomerService customerService = new CustomerService();
    bool status = customerService.DeleteCustomer(id);
    if (status)
        return Results.Ok();
    else
        return Results.BadRequest("Customer could not be added.");
});

app.Run();
