using Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : BaseController {

    [HttpGet]
    public async Task<IActionResult> GetProducts() {
        return HandleResult(await Mediator.Send(new List.Command { }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id) {
        return HandleResult(await Mediator.Send(new Detail.Command { Id = id }));
    }
}