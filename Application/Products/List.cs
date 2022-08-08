using Application.Core;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Products;

public class List {
  public class Command : IRequest<Result<List<Product>>> {

  }

  public class Handler : IRequestHandler<Command, Result<List<Product>>>
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public Handler(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Result<List<Product>>> Handle(Command request, CancellationToken cancellationToken)
    {
      var products = await _context.Products!.ToListAsync();
      return Result<List<Product>>.Success(products);
    }
  }
}