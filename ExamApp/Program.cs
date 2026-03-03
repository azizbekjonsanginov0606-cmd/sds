// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using Dapper;
using Domain.Models;
using Infrastructure.Interfeas;
using Infrastructure.Constext;
using Infrastructure.Services;

ICustomer customer = new CustomersServices();
IOrder order = new OrdersSrvices();
var customer1 = new Customer();
customer1.fullname = "Azizbek Sanginov";

// Console.WriteLine(await customer.AddCustomer(customer1));

// var c=await customer.GetAllCustomer();
// foreach (var item in c)
// {
//     Console.WriteLine($"{item.Id} | {item.fullname}");
// }
// var n=1;
// var ce =await customer.GetCustomerById(n);
// Console.WriteLine($"{ce?.Id}| {ce?.fullname}");

// var customer1new = new Customer();
// customer1new.Id=1;
// customer1new.fullname="Azizbeg Sanginov";

// await customer.UpdateCustomer(customer1new);

// await customer.DeleteCustomer(5);
// foreach (var item in c)
// {
//     Console.WriteLine($"{item.Id} | {item.fullname}");
// }

var Order1 = new Order();
Order1.customeriId = 1;
Order1.amount = 1524.50m;
Console.WriteLine(await order.AddOrder(Order1));


var o = await order.GetAllOrder();
foreach (var item in o)
{
    Console.WriteLine($"{item?.Id}| {item?.customeriId} | {item?.amount}");
}
var a = 1;
var or = await order.GetOrderById(a);
Console.WriteLine($"{or?.Id}| {or?.customeriId} | {or?.amount}");

var order1new = new Order();
order1new.Id = 1;
order1new.customeriId = 5;
order1new.amount = 2000.00m;

await order.UpdateOrder(order1new);

await order.DeleteOrder(5);
foreach (var item in o)
{
    Console.WriteLine($"{item?.Id}| {item?.customeriId} | {item?.amount}");
}